<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_event
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
        Me.XpListView2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XpListView2.ForeColor = System.Drawing.Color.Red
        Me.XpListView2.GridLines = True
        Me.XpListView2.Location = New System.Drawing.Point(3, 6)
        Me.XpListView2.Margin = New System.Windows.Forms.Padding(4)
        Me.XpListView2.Name = "XpListView2"
        Me.XpListView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.XpListView2.RightToLeftLayout = True
        Me.XpListView2.Size = New System.Drawing.Size(1304, 638)
        Me.XpListView2.TabIndex = 194
        Me.XpListView2.UseCompatibleStateImageBehavior = False
        Me.XpListView2.View = System.Windows.Forms.View.Details
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(570, 824)
        Me.ButtonX1.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(224, 51)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 195
        Me.ButtonX1.Text = "ÿ»«⁄Â"
        Me.ButtonX1.Visible = False
        '
        'Form_event
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(1320, 652)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.XpListView2)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_event"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "⁄„·Ì«  «·„” Œœ„Ì‰"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XpListView2 As mdobler.XPCommonControls.XPListView
    Private WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
End Class
