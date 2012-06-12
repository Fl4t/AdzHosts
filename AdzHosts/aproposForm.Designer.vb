<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class aproposForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(aproposForm))
        Me.adzPictureBox = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ForumLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.SiteLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.adzPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'adzPictureBox
        '
        Me.adzPictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.adzPictureBox.Image = Global.AdZHosts.My.Resources.Resources.adzLogo
        Me.adzPictureBox.Location = New System.Drawing.Point(306, 12)
        Me.adzPictureBox.Name = "adzPictureBox"
        Me.adzPictureBox.Size = New System.Drawing.Size(187, 276)
        Me.adzPictureBox.TabIndex = 0
        Me.adzPictureBox.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Créateur du logiciel :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Créateur du fichier :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(143, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Julien Stechele"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(143, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Hajdar Kakud"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Forum AdZHosts :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 198)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Page Officielle :"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(12, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(288, 55)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "AdZHosts Updater est un modeste logiciel de mise à  jour du fichier hosts. Ce log" & _
            "iciel est conçu pour le fichier d'Hajdar Kakud et donc fait office de bloqueurs " & _
            "de publicités sur internet."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ForumLinkLabel
        '
        Me.ForumLinkLabel.AutoSize = True
        Me.ForumLinkLabel.Location = New System.Drawing.Point(143, 172)
        Me.ForumLinkLabel.Name = "ForumLinkLabel"
        Me.ForumLinkLabel.Size = New System.Drawing.Size(146, 13)
        Me.ForumLinkLabel.TabIndex = 11
        Me.ForumLinkLabel.TabStop = True
        Me.ForumLinkLabel.Text = "http://adzhosts.free.fr/forum/"
        '
        'SiteLinkLabel
        '
        Me.SiteLinkLabel.AutoSize = True
        Me.SiteLinkLabel.Location = New System.Drawing.Point(143, 198)
        Me.SiteLinkLabel.Name = "SiteLinkLabel"
        Me.SiteLinkLabel.Size = New System.Drawing.Size(158, 13)
        Me.SiteLinkLabel.TabIndex = 12
        Me.SiteLinkLabel.TabStop = True
        Me.SiteLinkLabel.Text = "http://facebook.com/AdZHosts"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 275)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(171, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Copyright (c) 2012 Stechele Julien."
        '
        'aproposForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 300)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.SiteLinkLabel)
        Me.Controls.Add(Me.ForumLinkLabel)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.adzPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "aproposForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AdZHosts Updater v1.2"
        CType(Me.adzPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents adzPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ForumLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents SiteLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
