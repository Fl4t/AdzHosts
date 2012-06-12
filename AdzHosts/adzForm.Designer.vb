<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class adzForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(adzForm))
        Me.SyncButton = New System.Windows.Forms.Button()
        Me.QuitterButton = New System.Windows.Forms.Button()
        Me.LocalLabel = New System.Windows.Forms.Label()
        Me.NewLabel = New System.Windows.Forms.Label()
        Me.LocaleLabel = New System.Windows.Forms.Label()
        Me.ServeurLabel = New System.Windows.Forms.Label()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MiseAZeroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.QuitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjoutDeDomainesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SuppressionDeDomainesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AProposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DLBackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.DLProgressBar = New System.Windows.Forms.ProgressBar()
        Me.DLLabel = New System.Windows.Forms.Label()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'SyncButton
        '
        Me.SyncButton.Location = New System.Drawing.Point(34, 210)
        Me.SyncButton.Name = "SyncButton"
        Me.SyncButton.Size = New System.Drawing.Size(91, 23)
        Me.SyncButton.TabIndex = 0
        Me.SyncButton.Text = "&Mettre à jour"
        Me.SyncButton.UseVisualStyleBackColor = True
        '
        'QuitterButton
        '
        Me.QuitterButton.Location = New System.Drawing.Point(160, 210)
        Me.QuitterButton.Name = "QuitterButton"
        Me.QuitterButton.Size = New System.Drawing.Size(91, 23)
        Me.QuitterButton.TabIndex = 1
        Me.QuitterButton.Text = "&Quitter"
        Me.QuitterButton.UseVisualStyleBackColor = True
        '
        'LocalLabel
        '
        Me.LocalLabel.AutoSize = True
        Me.LocalLabel.Location = New System.Drawing.Point(68, 81)
        Me.LocalLabel.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.LocalLabel.Name = "LocalLabel"
        Me.LocalLabel.Size = New System.Drawing.Size(79, 13)
        Me.LocalLabel.TabIndex = 2
        Me.LocalLabel.Text = "Version locale :"
        '
        'NewLabel
        '
        Me.NewLabel.AutoSize = True
        Me.NewLabel.Location = New System.Drawing.Point(61, 116)
        Me.NewLabel.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.NewLabel.Name = "NewLabel"
        Me.NewLabel.Size = New System.Drawing.Size(86, 13)
        Me.NewLabel.TabIndex = 3
        Me.NewLabel.Text = "Version serveur :"
        '
        'LocaleLabel
        '
        Me.LocaleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LocaleLabel.ForeColor = System.Drawing.Color.Black
        Me.LocaleLabel.Location = New System.Drawing.Point(151, 77)
        Me.LocaleLabel.Name = "LocaleLabel"
        Me.LocaleLabel.Size = New System.Drawing.Size(71, 21)
        Me.LocaleLabel.TabIndex = 4
        Me.LocaleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ServeurLabel
        '
        Me.ServeurLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ServeurLabel.Location = New System.Drawing.Point(151, 111)
        Me.ServeurLabel.Name = "ServeurLabel"
        Me.ServeurLabel.Size = New System.Drawing.Size(71, 22)
        Me.ServeurLabel.TabIndex = 5
        Me.ServeurLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem, Me.EditionToolStripMenuItem, Me.AideToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(284, 24)
        Me.MenuStrip.TabIndex = 6
        Me.MenuStrip.Text = "MenuStrip"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MiseAZeroToolStripMenuItem, Me.ToolStripSeparator1, Me.QuitterToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.MenuToolStripMenuItem.Text = "M&enu"
        '
        'MiseAZeroToolStripMenuItem
        '
        Me.MiseAZeroToolStripMenuItem.Name = "MiseAZeroToolStripMenuItem"
        Me.MiseAZeroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.MiseAZeroToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.MiseAZeroToolStripMenuItem.Text = "Mise à &zéro du fichier hosts"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(241, 6)
        '
        'QuitterToolStripMenuItem
        '
        Me.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem"
        Me.QuitterToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.QuitterToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.QuitterToolStripMenuItem.Text = "&Quitter"
        '
        'EditionToolStripMenuItem
        '
        Me.EditionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AjoutDeDomainesToolStripMenuItem, Me.SuppressionDeDomainesToolStripMenuItem})
        Me.EditionToolStripMenuItem.Name = "EditionToolStripMenuItem"
        Me.EditionToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.EditionToolStripMenuItem.Text = "E&dition"
        '
        'AjoutDeDomainesToolStripMenuItem
        '
        Me.AjoutDeDomainesToolStripMenuItem.Name = "AjoutDeDomainesToolStripMenuItem"
        Me.AjoutDeDomainesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.AjoutDeDomainesToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.AjoutDeDomainesToolStripMenuItem.Text = "&Ajouts de domaines"
        '
        'SuppressionDeDomainesToolStripMenuItem
        '
        Me.SuppressionDeDomainesToolStripMenuItem.Name = "SuppressionDeDomainesToolStripMenuItem"
        Me.SuppressionDeDomainesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SuppressionDeDomainesToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.SuppressionDeDomainesToolStripMenuItem.Text = "&Suppressions de domaines"
        '
        'AideToolStripMenuItem
        '
        Me.AideToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AProposToolStripMenuItem})
        Me.AideToolStripMenuItem.Name = "AideToolStripMenuItem"
        Me.AideToolStripMenuItem.Size = New System.Drawing.Size(24, 20)
        Me.AideToolStripMenuItem.Text = "?"
        '
        'AProposToolStripMenuItem
        '
        Me.AProposToolStripMenuItem.Name = "AProposToolStripMenuItem"
        Me.AProposToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.AProposToolStripMenuItem.Text = "À propos..."
        '
        'DLBackgroundWorker
        '
        Me.DLBackgroundWorker.WorkerSupportsCancellation = True
        '
        'DLProgressBar
        '
        Me.DLProgressBar.Location = New System.Drawing.Point(78, 174)
        Me.DLProgressBar.Name = "DLProgressBar"
        Me.DLProgressBar.Size = New System.Drawing.Size(128, 11)
        Me.DLProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.DLProgressBar.TabIndex = 7
        '
        'DLLabel
        '
        Me.DLLabel.AutoSize = True
        Me.DLLabel.Location = New System.Drawing.Point(94, 158)
        Me.DLLabel.Name = "DLLabel"
        Me.DLLabel.Size = New System.Drawing.Size(96, 13)
        Me.DLLabel.TabIndex = 8
        Me.DLLabel.Text = "Veuillez patienter..."
        '
        'adzForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.DLLabel)
        Me.Controls.Add(Me.DLProgressBar)
        Me.Controls.Add(Me.ServeurLabel)
        Me.Controls.Add(Me.LocaleLabel)
        Me.Controls.Add(Me.NewLabel)
        Me.Controls.Add(Me.LocalLabel)
        Me.Controls.Add(Me.QuitterButton)
        Me.Controls.Add(Me.SyncButton)
        Me.Controls.Add(Me.MenuStrip)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "adzForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AdZHosts Updater v1.12"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SyncButton As System.Windows.Forms.Button
    Friend WithEvents QuitterButton As System.Windows.Forms.Button
    Friend WithEvents LocalLabel As System.Windows.Forms.Label
    Friend WithEvents NewLabel As System.Windows.Forms.Label
    Friend WithEvents LocaleLabel As System.Windows.Forms.Label
    Friend WithEvents ServeurLabel As System.Windows.Forms.Label
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MiseAZeroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AjoutDeDomainesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SuppressionDeDomainesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AProposToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DLBackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents DLProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents DLLabel As System.Windows.Forms.Label

End Class
