Public Class adminForm

    Private Sub AjoutUtilisateurButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AjoutUtilisateurButton.Click

        ' On déclare la variable contenant le login.
        Dim strAjoutLogin As String = AjoutUtilisateurTextBox.Text.Trim

        If mstrCollectionUtilisateurs.Contains(strAjoutLogin) Then
            ' Il existe déjà, donc on affiche un message d'érreur.
            ExisteDejaLabel.Visible = True
            AjoutUtilisateurTextBox.SelectAll()
        Else
            udtUtilisateurs.strLogin = strAjoutLogin
            udtUtilisateurs.strMdp = AjoutMdpTextBox.Text.Trim

            ' On n'ajoute pas l'utilisateur si le login ou le mot de passe est vide.
            If udtUtilisateurs.strLogin = "" OrElse udtUtilisateurs.strMdp = "" Then

                ' On affiche le message d'erreur.
                ChampLabel.Visible = True
            Else
                ' On ajoute l'utilisateur à la suite du fichier utilisateurs.data.
                FilePut(1, udtUtilisateurs, mstrCollectionUtilisateurs.Count + 1)
                MessageBox.Show("Ajout d'utilisateur reussi !", "AdZHosts Updater", MessageBoxButtons.OK, _
                                MessageBoxIcon.Information)

                ' On apelle la procédure pour actualiser la collection
                Call P_AjoutUtilisateursDansCollection()
            End If
        End If

    End Sub

    Private Sub AjoutUtilisateurTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                    Handles AjoutUtilisateurTextBox.TextChanged, _
                                                    AjoutMdpTextBox.TextChanged

        ' On efface les messages d'erreurs.
        ExisteDejaLabel.Visible = False
        ChampLabel.Visible = False

    End Sub

    Private Sub adminForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) _
                                        Handles Me.FormClosing

        ' On ferme le fichier utilisateurs.
        FileClose(1)

    End Sub

    Private Sub adminForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AjoutUtilisateurTextBox.Focus()

    End Sub

End Class