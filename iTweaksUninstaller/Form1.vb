Imports System.Net
Imports System.Management
Imports System.IO.Compression

Public Class Form1
    Public da As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\"
    Dim WithEvents client As New WebClient
    Public CurrentVersionInteger As Integer = 2
    Public CurrentVersion As String = "1.1"
    Dim Errors As Boolean
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ControlBox = False Then
            e.Cancel = True
        Else
            End_SSH_Over_USB()
            'CleanUpResources()
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CheckForIllegalCrossThreadCalls = False
        Me.Text = "iTweaksUninstaller v." & CurrentVersion.ToString
        Updater()
        CreateTempFolder()
        Download_iproxy()
        CheckForRenciDLL()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles DetectDeviceBackgroundWorker.DoWork
        If IsUserlandConnected() = True Then
            Label4.Text = "iOS device detected! To start, click the button below."
            MagicButton.Enabled = True
        Else
            Label4.Text = "Connect your iPhone, iPod touch or iPad to begin."
            MagicButton.Enabled = False
        End If
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Process.Start("https://api.ipsw.me/v2.1/iTunes/win/latest/url/dl")
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Process.Start("https://api.ipsw.me/v2.1/iTunes/win/latest/64biturl/dl")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles DetectDeviceTimer.Tick
        If pb.Value = 0 Then
            If DetectDeviceBackgroundWorker.IsBusy = False Then
                DetectDeviceBackgroundWorker.RunWorkerAsync()
            End If
        Else
            DetectDeviceBackgroundWorker.CancelAsync()
            MagicButton.Enabled = False
        End If
    End Sub

    Private Sub MagicButton_Click(sender As Object, e As EventArgs) Handles MagicButton.Click
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("http://paypal.me/leoalfreducci")
        '  MsgBox(DetectDeviceTimer.Enabled)
        ' MsgBox(BackgroundWorker1.IsBusy)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("http://twitter.com/Sn0wCooder")
    End Sub

    Public Sub Download_iproxy()
        If Not IO.Directory.Exists(da & "libimobiledevice") Then
            MsgBox("Downloading iproxy (only for the first time). It will take a while!", MsgBoxStyle.Information, "Warning")
            client.DownloadFile(New Uri("https://github.com/Sn0wCooder/libimobiledevice-compiled-windows/archive/master.zip"), da & "libimobiledevice.zip")
            ZipFile.ExtractToDirectory(da & "libimobiledevice.zip", da)
            IO.File.Delete(da & "libimobiledevice.zip")
            My.Computer.FileSystem.RenameDirectory(da & "libimobiledevice-compiled-windows-master", "libimobiledevice")
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Call DetectDeviceTimer.Stop()
        Call DetectDeviceBackgroundWorker.CancelAsync()
        MagicButton.Enabled = False
        ControlBox = False
        Try
            If Not MessageBox.Show("Do you really want to continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Cancel Then
                pb.Value = 20
                StatusLabel.Text = "Status: 20% - trying to start a SSH connection over USB..."
                End_SSH_Over_USB()
                SSH_Over_USB("22", "22")
                Dim connInfo As New Renci.SshNet.PasswordConnectionInfo("127.0.0.1", "root", "alpine")
                Dim sshClient As New Renci.SshNet.SshClient(connInfo)
                Dim sftpClient As New Renci.SshNet.SftpClient(connInfo)
                Dim cmd As Renci.SshNet.SshCommand
                Try
                    If sshClient.IsConnected = False Then
                        sshClient.Connect()
                    End If
                    If sshClient.IsConnected = True Then
                        sshClient.Disconnect()
                    End If
                Catch ex As Exception
                    MsgBox("There was an error during the procedure. Make sure the device is connected to the computer and that it have installed " _
                         & "OpenSSH and APT 0.6 Transitional from Cydia, and that the default password is " + """" + "alpine" + """" + "than retry. If the problem persists, restart your device or contact me." _
                         , MsgBoxStyle.Critical, "Warning")
                    ResetAll()
                    'Errors = True
                    Application.Restart()
                End Try
                'Errors = False
                If sshClient.IsConnected = False Then
                    sshClient.Connect()
                End If
                If sftpClient.IsConnected = False Then
                    sftpClient.Connect()
                End If
                pb.Value = 65
                StatusLabel.Text = "Status: 65% - getting all tweaks installed on the device..."
                cmd = sshClient.RunCommand("dpkg --get-selections")
                Dim Tweaks As String = cmd.Result
                Tweaks = Tweaks.Replace("install", Nothing)
                If System.IO.File.Exists(da & "tweaks.txt") Then
                    System.IO.File.Delete(da & "tweaks.txt")
                End If
                My.Computer.FileSystem.WriteAllText(da & "tweaks.txt", Tweaks, True)
                pb.Value = 70
                For Each tweak In System.IO.File.ReadLines(da & "tweaks.txt")
                    StatusLabel.Text = "Status: 70% - uninstalling tweak " & tweak & "..."
                    cmd = sshClient.RunCommand("dpkg -r " & tweak)
                    cmd = sshClient.RunCommand("dpkg -r " & tweak)
                Next
                pb.Value = 80
                StatusLabel.Text = "Status: 80% - clearing UICache..."
                cmd = sshClient.RunCommand("uicache")
                pb.Value = 99
                StatusLabel.Text = "Status: 99% - rebooting device..."
                Try
                    cmd = sshClient.RunCommand("reboot")
                Catch ex As Exception
                End Try
                pb.Value = 100
                StatusLabel.Text = "Status: 100% - done!"
                End_SSH_Over_USB()
                My.Computer.Audio.Play(My.Resources.sound_completed, AudioPlayMode.Background)
                If sshClient.IsConnected = True Then
                    sshClient.Disconnect()
                End If
                If sftpClient.IsConnected = True Then
                    sftpClient.Disconnect()
                End If
            End If
            ' Done.Show()
            ' Me.Hide()
            MsgBox("Done! Your device is rebooting now.", MsgBoxStyle.Information, "Warning")
            End
            ' ControlBox = True
            ' Call AfterTimer.Start()
            ' Call DetectDeviceTimer.Start()

        Catch ex As Exception
            'If Errors = False Then
            MsgBox("There was an error during the procedure. Please contact me. The error is: " & ex.Message, MsgBoxStyle.Critical, "Error")
            ResetAll()
            EndUninstallProcessBackgroungWorker()
            ' End If
        End Try
    End Sub

    Private Sub AfterTimer_Tick(sender As Object, e As EventArgs) Handles AfterTimer.Tick
        ResetAll()
    End Sub
    Public Sub ResetAll()
        ControlBox = True
        pb.Value = 0
        StatusLabel.Text = "Status: idle"
        End_SSH_Over_USB()
        DetectDeviceTimer.Start()
    End Sub
    Public Sub EndUninstallProcessBackgroungWorker()
        BackgroundWorker1.CancelAsync()
        Application.Restart()
    End Sub

    Private Sub DetectDeviceBackgroundWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles DetectDeviceBackgroundWorker.ProgressChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://raw.githubusercontent.com/Sn0wCooder/iTweaksUninstaller/master/iTweaksUninstaller_Master.zip")
    End Sub
End Class
