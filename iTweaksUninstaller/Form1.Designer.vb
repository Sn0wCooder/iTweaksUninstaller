<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AfterTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.MagicButton = New System.Windows.Forms.Button()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.pb = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.DetectDeviceBackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DetectDeviceTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(126, 9)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(28, 13)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "here"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "UPDATE_CHECKER"
        '
        'AfterTimer
        '
        Me.AfterTimer.Interval = 5000
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 281)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "By"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(376, 281)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(42, 13)
        Me.LinkLabel3.TabIndex = 21
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Donate"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(28, 281)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(102, 13)
        Me.LinkLabel2.TabIndex = 20
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Leonardo Alfreducci"
        '
        'MagicButton
        '
        Me.MagicButton.Location = New System.Drawing.Point(343, 240)
        Me.MagicButton.Name = "MagicButton"
        Me.MagicButton.Size = New System.Drawing.Size(75, 23)
        Me.MagicButton.TabIndex = 19
        Me.MagicButton.Text = "Uninstall"
        Me.MagicButton.UseVisualStyleBackColor = True
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Location = New System.Drawing.Point(12, 266)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(59, 13)
        Me.StatusLabel.TabIndex = 18
        Me.StatusLabel.Text = "Status: idle"
        '
        'pb
        '
        Me.pb.Location = New System.Drawing.Point(15, 240)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(322, 23)
        Me.pb.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(419, 169)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Location = New System.Drawing.Point(12, 90)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(125, 13)
        Me.LinkLabel4.TabIndex = 24
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Download iTunes (32-bit)"
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.Location = New System.Drawing.Point(12, 103)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(125, 13)
        Me.LinkLabel5.TabIndex = 25
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "Download iTunes (64-bit)"
        '
        'DetectDeviceBackgroundWorker
        '
        Me.DetectDeviceBackgroundWorker.WorkerReportsProgress = True
        Me.DetectDeviceBackgroundWorker.WorkerSupportsCancellation = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 212)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(243, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Connect your iPhone, iPod touch or iPad to begin."
        '
        'DetectDeviceTimer
        '
        Me.DetectDeviceTimer.Enabled = True
        Me.DetectDeviceTimer.Interval = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 303)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LinkLabel5)
        Me.Controls.Add(Me.LinkLabel4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LinkLabel3)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.MagicButton)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.pb)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "iTweaksUninstaller v.X"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AfterTimer As System.Windows.Forms.Timer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents MagicButton As System.Windows.Forms.Button
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents pb As System.Windows.Forms.ProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel5 As System.Windows.Forms.LinkLabel
    Friend WithEvents DetectDeviceBackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DetectDeviceTimer As System.Windows.Forms.Timer

End Class
