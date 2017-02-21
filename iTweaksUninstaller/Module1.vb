Imports System.Management
Imports System.Net
Module Module1
    Dim da As String = Form1.da
    Dim WithEvents client As New WebClient

    Public Sub Updater()
        If CheckForInternetConnection() = True Then
            Dim versione As Integer = client.DownloadString("https://raw.githubusercontent.com/Sn0wCooder/iTweaksUninstaller/master/value.txt")
            If versione > Form1.CurrentVersionInteger Then
                Dim nuovaversione As String = client.DownloadString("https://raw.githubusercontent.com/Sn0wCooder/iTweaksUninstaller/master/latestversion.txt")
                Form1.LinkLabel1.Show()
                Form1.Label1.Show()
                Form1.Label1.Text = "A new version of this application is avaiable: " & nuovaversione.ToString & ". Download it"
                Form1.LinkLabel1.Location = New Point(Form1.Label1.Size.Width + 9, Form1.LinkLabel1.Location.Y)
            Else
                Form1.LinkLabel1.Hide()
                Form1.Label1.Show()
                Form1.Label1.Text = "Hi! This is the latest version of iBackuPackages."
            End If
        Else
            Form1.LinkLabel1.Hide()
            Form1.Label1.Show()
            Form1.Label1.Text = "Unable to check for update. Your internet connection isn't avaiable."
        End If
    End Sub

    Public Function IncrementProgressBar(ByVal value As Integer)
        Form1.pb.Value = value
    End Function
    Public Function IncrementLabel(ByVal Percentage As Integer, ByVal Text As String, Optional ByVal done As Boolean = False)
        If done = True Then
            Form1.StatusLabel.Text = "Status: " & Percentage & "% - " & Text
        Else
            Form1.StatusLabel.Text = "Status: 100% - done!"
        End If
    End Function
    Public Sub CheckForRenciDLL()
        If Not System.IO.File.Exists(Application.StartupPath & "\Renci.SshNet.dll") Then
            My.Computer.FileSystem.WriteAllBytes(Application.StartupPath & "\Renci.SshNet.dll", My.Resources.Renci_SshNet, True)
        End If
    End Sub

    Public Sub CreateTempFolder()
        If Not My.Computer.FileSystem.DirectoryExists(da) Then
            My.Computer.FileSystem.CreateDirectory(da)
        End If
    End Sub

    'Public Sub CleanUpResources()
    '   End_SSH_Over_USB()
    '   If My.Computer.FileSystem.DirectoryExists(da) Then
    '       My.Computer.FileSystem.DeleteDirectory(da, FileIO.DeleteDirectoryOption.DeleteAllContents)
    '    End If
    'End Sub
    Public Sub iproxy(args As String)
        Dim iproxy As New Process()
        Try
            iproxy.StartInfo.UseShellExecute = False
            iproxy.StartInfo.FileName = Form1.da + "libimobiledevice\iproxy.exe"
            iproxy.StartInfo.Arguments = args
            iproxy.StartInfo.CreateNoWindow = True
            iproxy.Start()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SSH_Over_USB(iport As String, lport As String)
        iproxy(iport + " " + lport)
    End Sub

    Public Sub End_SSH_Over_USB()
        Kill({"iproxy"})
    End Sub

    Public Sub Kill(ProcessesList As String())
        For Each ProcessName In ProcessesList
            Dim SubProcesses() As Process = Process.GetProcessesByName(ProcessName)
            For Each SubProcess As Process In SubProcesses
                If IsProcessRunning(SubProcess.ProcessName) = True Then
                    SubProcess.Kill()
                End If
            Next
        Next
    End Sub

    Public Function IsProcessRunning(name As String) As Boolean
        For Each clsProcess As Process In Process.GetProcesses()
            If clsProcess.ProcessName.StartsWith(name) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function IsUserlandConnected()
        Dim forever As Boolean = True
        Dim USBName As String = String.Empty
        Dim USBSearcher As New ManagementObjectSearcher( _
                      "root\CIMV2", _
                      "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Mobile Device USB Driver'")
        For Each queryObj As ManagementObject In USBSearcher.Get()
            USBName += (queryObj("Description"))
        Next
        If USBName = "Apple Mobile Device USB Driver" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function IsDFUConnected()
        Dim forever As Boolean = True
        Dim text1 As String = ""
        text1 = " "
        Dim searcher As New ManagementObjectSearcher( _
                  "root\CIMV2", _
                  "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Recovery (DFU) USB Driver'")
        For Each queryObj As ManagementObject In searcher.Get()

            text1 += (queryObj("Description"))
        Next
        If text1.Contains("DFU") Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function IsRecoveryConnected()
        Dim text1 As String = ""
        text1 = " "
        Dim searcher As New ManagementObjectSearcher( _
                  "root\CIMV2", _
                  "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Recovery (iBoot) USB Driver'")
        For Each queryObj As ManagementObject In searcher.Get()

            text1 += (queryObj("Description"))
        Next
        If text1.Contains("iBoot") Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CheckForInternetConnection() As Boolean
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com")
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function
End Module
