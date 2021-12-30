<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SpriteTimer = New System.Windows.Forms.Timer(Me.components)
        Me.JumpTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Mvmnt = New System.Windows.Forms.Timer(Me.components)
        Me.Intersect = New System.Windows.Forms.Timer(Me.components)
        Me.Enemy = New System.Windows.Forms.Timer(Me.components)
        Me.Boss = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'SpriteTimer
        '
        Me.SpriteTimer.Enabled = True
        '
        'JumpTimer
        '
        Me.JumpTimer.Enabled = True
        Me.JumpTimer.Interval = 20
        '
        'Mvmnt
        '
        Me.Mvmnt.Enabled = True
        Me.Mvmnt.Interval = 2
        '
        'Intersect
        '
        Me.Intersect.Enabled = True
        Me.Intersect.Interval = 1
        '
        'Enemy
        '
        Me.Enemy.Enabled = True
        Me.Enemy.Interval = 1
        '
        'Boss
        '
        Me.Boss.Enabled = True
        Me.Boss.Interval = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(684, 661)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.White
        Me.MaximumSize = New System.Drawing.Size(700, 700)
        Me.Name = "Form1"
        Me.Text = "Kirby Dreamland: Demo"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SpriteTimer As System.Windows.Forms.Timer
    Friend WithEvents JumpTimer As System.Windows.Forms.Timer
    Friend WithEvents Mvmnt As System.Windows.Forms.Timer
    Friend WithEvents Intersect As System.Windows.Forms.Timer
    Friend WithEvents Enemy As System.Windows.Forms.Timer
    Friend WithEvents Boss As System.Windows.Forms.Timer

End Class
