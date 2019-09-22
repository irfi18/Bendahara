Imports MySql.Data.MySqlClient

Public Class InputPemasukan

    Dim namaPengurus As String
    Dim idPengurus As Integer
    Dim Tanggal As String

    Sub ambilPengurus(ByVal usr As String)
        Dim str As String
        str = "select * from pengurus where username = '" & usr & "'"
        cmd = New MySqlCommand(str, koneksi)
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            namaPengurus = dtr.Item("nama")
            idPengurus = dtr.Item("id")

        Else
        End If
        dtr.Close()
    End Sub

    Sub ambilanggota()
        Try
            Dim str As String
            str = "select * from member "
            cmd = New MySqlCommand(str, koneksi)
            dtr = cmd.ExecuteReader

            If dtr.HasRows Then
                While dtr.Read
                    cbIdMember.Items.Add(dtr("id"))
                End While
            End If
            dtr.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Pemasukan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ambilanggota()
        ambilPengurus(user)
        tbPengurus.Text = namaPengurus
        tbIdPengurus.Text = idPengurus
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        'Tanggal = Format(DtTanggal.Value, "yyyy-MM-dd")
        If (cbIdMember.Text = "" Or tbNominal.Text = "") Then
            MsgBox("Data Belum Lengkap")
        Else
            Try
                crud("Insert into pemasukan value ('""','" & tbNominal.Text & "','" & Format(DtTanggal.Value, "yyyy-MM-dd") & "','" & tbIdPengurus.Text & "','" & cbIdMember.SelectedItem & "')")
                MsgBox("Berhasil disimpan")
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

    Private Sub cbIdMember_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbIdMember.SelectedIndexChanged
        Try
            Dim str As String
            str = "select * from member where id = '" & cbIdMember.SelectedItem & "'"
            cmd = New MySqlCommand(str, koneksi)
            dtr = cmd.ExecuteReader
            dtr.Read()
            If dtr.HasRows Then
                tbMember.Text = dtr.Item("nama")
            End If
            dtr.Close()
        Catch ex As Exception
        End Try
    End Sub

End Class