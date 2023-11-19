<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.XpListView2 = New mdobler.XPCommonControls.XPListView
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX
        Me.SuspendLayout()
        '
        'XpListView2
        '
        Me.XpListView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.XpListView2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XpListView2.ForeColor = System.Drawing.Color.Blue
        Me.XpListView2.GridLines = True
        Me.XpListView2.Location = New System.Drawing.Point(12, 14)
        Me.XpListView2.Name = "XpListView2"
        Me.XpListView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.XpListView2.RightToLeftLayout = True
        Me.XpListView2.Size = New System.Drawing.Size(870, 453)
        Me.XpListView2.TabIndex = 194
        Me.XpListView2.UseCompatibleStateImageBehavior = False
        Me.XpListView2.View = System.Windows.Forms.View.Details
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(355, 481)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(184, 35)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 195
        Me.ButtonX1.Text = "ÿ»«⁄Â"
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(886, 528)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.XpListView2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form5"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "‰ﬁÿ… «⁄«œ… «·ÿ·» ··«’‰«›"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XpListView2 As mdobler.XPCommonControls.XPListView
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
End Class
