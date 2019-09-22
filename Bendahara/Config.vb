Imports MySql.Data.MySqlClient

Module Config
    Public koneksi As MySqlConnection
    Public cmd As MySqlCommand
    Public dtr As MySqlDataReader
    Public adp As MySqlDataAdapter
    Public dts As DataSet
    Public status As Boolean = False
    Public edit As Boolean = False
    Public user As String
    Sub connection()
        Try

            Dim query As String = "server=127.0.0.1;Uid=root;pwd=;database=keuangan;port=3306"
            koneksi = New MySqlConnection(query)
            If koneksi.State = ConnectionState.Closed Then
                koneksi.Open()
                status = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub tampilan(ByVal dgp As DataGridView, ByVal tbl As String)
        Try
            Dim query As String = "select * from " & tbl
            adp = New MySqlDataAdapter(query, koneksi)
            dts = New DataSet
            dts.Clear()
            adp.Fill(dts, "select * from " & tbl)
            dgp.DataSource = (dts.Tables("select * from " & tbl))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error")
        End Try
    End Sub

    Sub crud(ByVal q As String)
        Try
            Dim query As String = q
            cmd = New MySqlCommand(query, koneksi)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error")
        End Try

    End Sub

    Dim hak_akses As String
    Sub getPengurus(ByVal usr As String)
        Call connection()
        Dim str As String
        str = "select * from pengurus where username = '" & usr & "'"
        cmd = New MySqlCommand(str, koneksi)
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            hak_akses = dtr.Item("jabatan")
        Else
        End If
        dtr.Close()
    End Sub

    Sub logina(ByVal txt As TextBox, ByVal txt2 As TextBox)
        Try
            connection()
            user = txt.Text
            cmd = New MySqlCommand("Select * from pengurus where username='" & txt.Text & "' and password='" & txt2.Text & "'", koneksi)
            dtr = cmd.ExecuteReader
            dtr.Read()
            If (dtr.HasRows = True) Then

                getPengurus(user)
                If hak_akses = "Ketua Umum" Or hak_akses = "Bendahara" Then
                    Menu.LoginToolStripMenuItem.Visible = False
                    Menu.InputToolStripMenuItem.Visible = True
                    Menu.DataToolStripMenuItem.Visible = True
                Else
                    Menu.LoginToolStripMenuItem.Visible = False
                    Menu.InputToolStripMenuItem.Visible = False
                    Menu.DataToolStripMenuItem.Visible = True
                End If
                Menu.ToolStripStatusLabel2.Text = hak_akses
                Menu.LogoutToolStripMenuItem.Visible = True
                MsgBox("login Sukses")
                Menu.Show()
                Login.Close()
            Else
                MsgBox("login gagal")
                dtr.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error")
        End Try
    End Sub

    Sub logout()
        Menu.InputToolStripMenuItem.Visible = False
        Menu.DataToolStripMenuItem.Visible = False
        Menu.LogoutToolStripMenuItem.Visible = False
        Menu.LoginToolStripMenuItem.Visible = True
        Menu.ToolStripStatusLabel2.Text = ""
        MsgBox("Logout Sukses")
    End Sub

    Sub cari(ByVal dgp As DataGridView, ByVal tbl As String, ByVal txt As TextBox, ByVal field As String)
        Try
            Dim query As String = "select * from " & tbl & " where " & field & " like '%" & txt.Text & "%'"
            adp = New MySqlDataAdapter(query, koneksi)
            dts = New DataSet
            dts.Clear()
            adp.Fill(dts, "select * from " & tbl & " where " & field & " like '%" & txt.Text & "%'")
            dgp.DataSource = (dts.Tables("select * from " & tbl & " where " & field & " like '%" & txt.Text & "%'"))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error")
        End Try

    End Sub
End Module
