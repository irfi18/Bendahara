Imports MySql.Data.MySqlClient

Public Class Anggota
    Dim field As String = ""
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

    Private Sub Anggota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tampilan(DataGridView1, "member")
        Me.ContextMenuStrip = ContextMenuStrip1
        getPengurus(user)
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UbahToolStripMenuItem.Click
        If hak_akses = "Ketua Umum" Or hak_akses = "Bendahara" Then
            Try
                With DataGridView1
                    InputAnggot.tbId.Text = .Item(0, .CurrentRow.Index).Value
                    InputAnggot.tbNim.Text = .Item(1, .CurrentRow.Index).Value
                    InputAnggot.tbNama.Text = .Item(2, .CurrentRow.Index).Value
                    InputAnggot.cbJurusan.SelectedItem = .Item(3, .CurrentRow.Index).Value
                    InputAnggot.tbNohp.Text = .Item(4, .CurrentRow.Index).Value
                    InputAnggot.tbNim.ReadOnly = True
                End With
                edit = True
                InputAnggot.Show()
            Catch ex As Exception
                MsgBox("error" & ex.Message)
            End Try
            Me.Close()
        Else
            MsgBox("Akses Ditolak")
        End If
    End Sub

    Private Sub HapusToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusToolStripMenuItem.Click
        Dim query As String
        If hak_akses = "Ketua Umum" Or hak_akses = "Bendahara" Then
            Try
                With DataGridView1
                    query = "Delete From member where id ='" & .Item(0, .CurrentRow.Index).Value & "'"
                End With
                cmd = New MySqlCommand(query, koneksi)
                cmd.ExecuteNonQuery()
                MsgBox("Berhasil dihapus")
                tampilan(DataGridView1, "member")
            Catch ex As Exception
                MsgBox("error" & ex.Message)
            End Try
        Else
            MsgBox("Akses Ditolak")
        End If

    End Sub

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        cari(DataGridView1, "member", tbCari, field)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        field = ComboBox1.SelectedItem.ToString
        If (field = "NIM") Then
            field = "nim"
        ElseIf (field = "Nama") Then
            field = "nama"
        ElseIf (field = "Jurusan") Then
            field = "jurusan"
        End If
    End Sub
End Class