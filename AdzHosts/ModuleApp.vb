Module ModuleApp

    Structure Enr_Utilisateur
        <VBFixedString(16)> Public strLogin As String
        <VBFixedString(16)> Public strMdp As String
    End Structure

    ' On déclare une variable d'enregistrement.
    Public udtUtilisateurs As Enr_Utilisateur

    ' On déclare une collection comprenant les utilisateurs via le load du formulaire loginForm.
    Public mstrCollectionUtilisateurs As New Collection
    Public objConnexionForm As New ConnexionForm

    Sub main()

        objConnexionForm.ShowDialog()

    End Sub

    Public Sub P_AjoutUtilisateursDansCollection()

        ' On enregistre chaque "compte" dans la collection.
        Do
            ' On insert les utilisateurs à la suite des autres.
            FileGet(1, udtUtilisateurs, mstrCollectionUtilisateurs.Count + 1)

            ' On enlève les espaces.
            udtUtilisateurs.strLogin = udtUtilisateurs.strLogin.Trim
            udtUtilisateurs.strMdp = udtUtilisateurs.strMdp.Trim

            ' Empeche l'ajout d'un utilisateur "" quand le fichier et vide.
            If udtUtilisateurs.strLogin <> "" AndAlso udtUtilisateurs.strMdp <> "" Then
                mstrCollectionUtilisateurs.Add(udtUtilisateurs.strMdp, udtUtilisateurs.strLogin)
            End If
        Loop Until EOF(1)
    End Sub

End Module