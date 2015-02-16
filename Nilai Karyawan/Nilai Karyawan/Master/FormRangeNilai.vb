Public Class FormRangeNilai

    Private koneksi As KoneksiDB = New KoneksiDB()

    Private Sub btnKembali_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKembali.Click
        Me.Close()
    End Sub

    Private Sub reset()
        btnHapus.Visible = False
        btnSimpan.Text = "Simpan"
        txtIdRange.Text = koneksi.generateId("RN", "range_nilai", "id_range", 3)
        cbKriteria.Text = Nothing
        txtKeterangan.Text = Nothing
        txtNilaiAtas.Value = 0
        txtNilaiBawah.Value = 0
        koneksi.isiComboBox(cbKriteria, "kriteria", "id_kriteria", "nama_kriteria")
        koneksi.queryDataGrid(dgvRange, "select id_range, a.id_kriteria, b.nama_kriteria, ket_range, nilai_atas, nilai_bawah from range_nilai a, kriteria b where a.id_kriteria = b.id_kriteria")
        dgvRange.Columns(0).HeaderText = "Id Range"
        dgvRange.Columns(0).Width = 40
        dgvRange.Columns(1).Visible = False
        dgvRange.Columns(2).HeaderText = "Kriteria"
        dgvRange.Columns(2).Width = 50
        dgvRange.Columns(3).HeaderText = "Keterangan"
        dgvRange.Columns(4).HeaderText = "Mulai"
        dgvRange.Columns(4).Width = 35
        dgvRange.Columns(5).HeaderText = "Sampai"
        dgvRange.Columns(5).Width = 35
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub FormRangeNilai_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            koneksi.buka()
            reset()
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan! Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatal.Click
        reset()
    End Sub

    Private Sub btnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHapus.Click
        Try
            If MessageBox.Show(Me, "Yakin dihapus?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "delete from kriteria where id_kriteria = '" & txtIdRange.Text & "'"
                Dim affectedRows As Integer = koneksi.nonQuery(query)
                If affectedRows > 0 Then
                    MessageBox.Show(Me, "Operasi berhasil dilakukan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reset()
                Else
                    MessageBox.Show(Me, "Operasi gagal dilakukan", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan! Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        Try
            If btnSimpan.Text = "Simpan" Then
                Dim query As String = "insert into range_nilai values('" & txtIdRange.Text & "', '" & cbKriteria.SelectedValue & "', '" & txtKeterangan.Text & "', " & txtNilaiAtas.Value & ", " & txtNilaiBawah.Value & ")"
                Dim affectedRows As Integer = koneksi.nonQuery(query)
                If affectedRows > 0 Then
                    MessageBox.Show(Me, "Operasi berhasil dilakukan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reset()
                Else
                    MessageBox.Show(Me, "Operasi gagal dilakukan", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf btnSimpan.Text = "Ubah" Then
                Dim query As String = "update range_nilai set id_kriteria = '" & cbKriteria.SelectedValue & "', ket_range = '" & txtKeterangan.Text & "', nilai_atas = '" & txtNilaiAtas.Value & "', nilai_bawah = '" & txtNilaiBawah.Value & "' where id_range = '" & txtIdRange.Text & "'"
                Dim affectedRows As Integer = koneksi.nonQuery(query)
                If affectedRows > 0 Then
                    MessageBox.Show(Me, "Operasi berhasil dilakukan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reset()
                Else
                    MessageBox.Show(Me, "Operasi gagal dilakukan", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan! Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvRange_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRange.CellContentDoubleClick
        Dim row As DataGridViewRow = dgvRange.CurrentRow

        txtIdRange.Text = row.Cells(0).Value
        cbKriteria.SelectedValue = row.Cells(1).Value
        txtKeterangan.Text = row.Cells(3).Value
        txtNilaiAtas.Value = row.Cells(4).Value
        txtNilaiBawah.Value = row.Cells(5).Value

        btnHapus.Visible = True
        btnSimpan.Text = "Ubah"

        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub dgvRange_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvRange.RowHeaderMouseDoubleClick
        Dim row As DataGridViewRow = dgvRange.CurrentRow

        txtIdRange.Text = row.Cells(0).Value
        cbKriteria.SelectedValue = row.Cells(1).Value
        txtKeterangan.Text = row.Cells(3).Value
        txtNilaiAtas.Value = row.Cells(4).Value
        txtNilaiBawah.Value = row.Cells(5).Value

        btnHapus.Visible = True
        btnSimpan.Text = "Ubah"

        TabControl1.SelectedIndex = 1
    End Sub
End Class