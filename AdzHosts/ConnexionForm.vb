Public Class ConnexionForm

    Private Sub ConnexionButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnexionButton.Click

        ' Si l'utilisateur est administrateur, on passe au formulaire adminForm.
        If LoginTextBox.Text = "admin" Then
            If MdpTextBox.Text = "admin" Then
                Dim objadminForm As New adminForm
                objadminForm.ShowDialog()
            Else
                ErreurMdpLabel.Visible = True
                MdpTextBox.SelectAll()
            End If
        Else
            Dim strTextLogin As String = LoginTextBox.Text.TrimEnd
            Dim strTextMdp As String = MdpTextBox.Text.TrimEnd

            ' Si la collection contient le login, on test si le mot de passe est correct,
            ' sinon il y a une erreur de login.
            If mstrCollectionUtilisateurs.Contains(strTextLogin) Then
                If mstrCollectionUtilisateurs.Item(strTextLogin) = strTextMdp Then

                    ' Si le login et le mot de passe sont bon, on lance le formulaire adzForm.
                    'Me.Hide()
                    Dim objadzForm As New adzForm
                    objadzForm.ShowDialog()
                    FileClose(1)
                    Me.Close()
                Else
                    ErreurMdpLabel.Visible = True
                    MdpTextBox.SelectAll()
                End If
            Else
                ErreurLoginLabel.Visible = True
                LoginTextBox.SelectAll()
            End If
        End If
    End Sub

    Private Sub ConnexionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' On ouvre un fichier data qui stocke les utilisateurs.
        FileOpen(1, "utilisateurs.data", OpenMode.Random, , , Len(udtUtilisateurs))

        ' On apelle la procédure de Comptage d'utilisateurs.
        Call P_AjoutUtilisateursDansCollection()
        LoginTextBox.Focus()
    End Sub

    Private Sub LoginTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles LoginTextBox.GotFocus

        ' On sélectionne tout
        LoginTextBox.SelectAll()

    End Sub

    Private Sub MdpTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MdpTextBox.GotFocus

        ' On sélectionne tout
        MdpTextBox.SelectAll()

    End Sub
    Private Sub LoginTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles LoginTextBox.TextChanged, MdpTextBox.TextChanged

        ' On efface les messages d'erreurs.
        ErreurLoginLabel.Visible = False
        ErreurMdpLabel.Visible = False

    End Sub

End Class