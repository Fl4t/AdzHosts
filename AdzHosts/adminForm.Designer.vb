<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class adminForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(adminForm))
        Me.AjoutUtilisateurButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AjoutUtilisateurTextBox = New System.Windows.Forms.TextBox()
        Me.AjoutMdpTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ExisteDejaLabel = New System.Windows.Forms.Label()
        Me.ChampLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'AjoutUtilisateurButton
        '
        Me.AjoutUtilisateurButton.Location = New System.Drawing.Point(57, 138)
        Me.AjoutUtilisateurButton.Name = "AjoutUtilisateurButton"
        Me.AjoutUtilisateurButton.Size = New System.Drawing.Size(127, 23)
        Me.AjoutUtilisateurButton.TabIndex = 6
        Me.AjoutUtilisateurButton.Text = "Ajouter l'utilisateur"
        Me.AjoutUtilisateurButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(70, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nom de l'utilisateur :"
        '
        'AjoutUtilisateurTextBox
        '
        Me.AjoutUtilisateurTextBox.Location = New System.Drawing.Point(70, 37)
        Me.AjoutUtilisateurTextBox.Name = "AjoutUtilisateurTextBox"
        Me.AjoutUtilisateurTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AjoutUtilisateurTextBox.TabIndex = 1
        '
        'AjoutMdpTextBox
        '
        Me.AjoutMdpTextBox.Location = New System.Drawing.Point(70, 81)
        Me.AjoutMdpTextBox.Name = "AjoutMdpTextBox"
        Me.AjoutMdpTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AjoutMdpTextBox.TabIndex = 3
        Me.AjoutMdpTextBox.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(70, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Mot de passe :"
        '
        'ExisteDejaLabel
        '
        Me.ExisteDejaLabel.AutoSize = True
        Me.ExisteDejaLabel.ForeColor = System.Drawing.Color.Red
        Me.ExisteDejaLabel.Location = New System.Drawing.Point(63, 115)
        Me.ExisteDejaLabel.Name = "ExisteDejaLabel"
        Me.ExisteDejaLabel.Size = New System.Drawing.Size(115, 13)
        Me.ExisteDejaLabel.TabIndex = 5
        Me.ExisteDejaLabel.Text = "L'utilisateur existe déjà."
        Me.ExisteDejaLabel.Visible = False
        '
        'ChampLabel
        '
        Me.ChampLabel.AutoSize = True
        Me.ChampLabel.ForeColor = System.Drawing.Color.Red
        Me.ChampLabel.Location = New System.Drawing.Point(23, 115)
        Me.ChampLabel.Name = "ChampLabel"
        Me.ChampLabel.Size = New System.Drawing.Size(195, 13)
        Me.ChampLabel.TabIndex = 4
        Me.ChampLabel.Text = "Vous devez renseigner tout les champs."
        Me.ChampLabel.Visible = False
        '
        'adminForm
        '
        Me.AcceptButton = Me.AjoutUtilisateurButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(241, 173)
        Me.Controls.Add(Me.ChampLabel)
        Me.Controls.Add(Me.ExisteDejaLabel)
        Me.Controls.Add(Me.AjoutMdpTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.AjoutUtilisateurTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AjoutUtilisateurButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "adminForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AdZHosts Updater v1.11"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AjoutUtilisateurButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AjoutUtilisateurTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AjoutMdpTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ExisteDejaLabel As System.Windows.Forms.Label
    Friend WithEvents ChampLabel As System.Windows.Forms.Label
End Class
