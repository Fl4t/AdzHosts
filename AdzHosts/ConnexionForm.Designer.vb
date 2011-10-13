<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConnexionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConnexionForm))
        Me.ConnexionButton = New System.Windows.Forms.Button
        Me.MdpLabel = New System.Windows.Forms.Label
        Me.LoginLabel = New System.Windows.Forms.Label
        Me.MdpTextBox = New System.Windows.Forms.TextBox
        Me.LoginTextBox = New System.Windows.Forms.TextBox
        Me.ErreurMdpLabel = New System.Windows.Forms.Label
        Me.ErreurLoginLabel = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ConnexionButton
        '
        Me.ConnexionButton.Location = New System.Drawing.Point(105, 155)
        Me.ConnexionButton.Name = "ConnexionButton"
        Me.ConnexionButton.Size = New System.Drawing.Size(75, 23)
        Me.ConnexionButton.TabIndex = 4
        Me.ConnexionButton.Text = "Connexion"
        Me.ConnexionButton.UseVisualStyleBackColor = True
        '
        'MdpLabel
        '
        Me.MdpLabel.AutoSize = True
        Me.MdpLabel.Location = New System.Drawing.Point(92, 92)
        Me.MdpLabel.Name = "MdpLabel"
        Me.MdpLabel.Size = New System.Drawing.Size(77, 13)
        Me.MdpLabel.TabIndex = 2
        Me.MdpLabel.Text = "Mot de passe :"
        '
        'LoginLabel
        '
        Me.LoginLabel.AutoSize = True
        Me.LoginLabel.Location = New System.Drawing.Point(92, 42)
        Me.LoginLabel.Name = "LoginLabel"
        Me.LoginLabel.Size = New System.Drawing.Size(39, 13)
        Me.LoginLabel.TabIndex = 0
        Me.LoginLabel.Text = "Login :"
        '
        'MdpTextBox
        '
        Me.MdpTextBox.Location = New System.Drawing.Point(92, 111)
        Me.MdpTextBox.Name = "MdpTextBox"
        Me.MdpTextBox.Size = New System.Drawing.Size(100, 20)
        Me.MdpTextBox.TabIndex = 3
        Me.MdpTextBox.UseSystemPasswordChar = True
        '
        'LoginTextBox
        '
        Me.LoginTextBox.Location = New System.Drawing.Point(92, 61)
        Me.LoginTextBox.Name = "LoginTextBox"
        Me.LoginTextBox.Size = New System.Drawing.Size(100, 20)
        Me.LoginTextBox.TabIndex = 1
        '
        'ErreurMdpLabel
        '
        Me.ErreurMdpLabel.AutoSize = True
        Me.ErreurMdpLabel.ForeColor = System.Drawing.Color.Red
        Me.ErreurMdpLabel.Location = New System.Drawing.Point(51, 181)
        Me.ErreurMdpLabel.Name = "ErreurMdpLabel"
        Me.ErreurMdpLabel.Size = New System.Drawing.Size(187, 13)
        Me.ErreurMdpLabel.TabIndex = 5
        Me.ErreurMdpLabel.Text = "Le mot de passe saisi n'est pas valide."
        Me.ErreurMdpLabel.Visible = False
        '
        'ErreurLoginLabel
        '
        Me.ErreurLoginLabel.AutoSize = True
        Me.ErreurLoginLabel.ForeColor = System.Drawing.Color.Red
        Me.ErreurLoginLabel.Location = New System.Drawing.Point(69, 181)
        Me.ErreurLoginLabel.Name = "ErreurLoginLabel"
        Me.ErreurLoginLabel.Size = New System.Drawing.Size(146, 13)
        Me.ErreurLoginLabel.TabIndex = 9
        Me.ErreurLoginLabel.Text = "Le login saisi n'est pas valide."
        Me.ErreurLoginLabel.Visible = False
        '
        'ConnexionForm
        '
        Me.AcceptButton = Me.ConnexionButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 227)
        Me.Controls.Add(Me.ErreurMdpLabel)
        Me.Controls.Add(Me.ErreurLoginLabel)
        Me.Controls.Add(Me.MdpLabel)
        Me.Controls.Add(Me.LoginLabel)
        Me.Controls.Add(Me.MdpTextBox)
        Me.Controls.Add(Me.LoginTextBox)
        Me.Controls.Add(Me.ConnexionButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ConnexionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AdZHosts Updater v0.1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ConnexionButton As System.Windows.Forms.Button
    Friend WithEvents MdpLabel As System.Windows.Forms.Label
    Friend WithEvents LoginLabel As System.Windows.Forms.Label
    Friend WithEvents MdpTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LoginTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ErreurMdpLabel As System.Windows.Forms.Label
    Friend WithEvents ErreurLoginLabel As System.Windows.Forms.Label
End Class
