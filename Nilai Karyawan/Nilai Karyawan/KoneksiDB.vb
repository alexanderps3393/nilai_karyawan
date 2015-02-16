Imports MySql.Data.MySqlClient

Public Class KoneksiDB

    Private server As String = "localhost"
    Private user As String = "root"
    Private password As String = ""
    Private database As String = ""
    Private connstr As String
    Private conn As MySqlConnection = New MySqlConnection()
    Private command As MySqlCommand
    Private reader As MySqlDataReader
    Private adapter As MySqlDataAdapter
    Private dataset As DataSet
    Private datatabel As DataTable

    Public Sub New(ByVal server As String, ByVal user As String, ByVal password As String, ByVal database As String)
        Me.server = server
        Me.user = user
        Me.password = password
        Me.database = database

        Me.connstr = "server=" & Me.server & ";user=" & Me.user & ";password=" & Me.password & ";database=" & Me.database & ";allow user variables=true"

        conn = New MySqlConnection(connstr)
    End Sub

    Public Sub New(ByVal database As String)
        Me.database = database

        Me.connstr = "server=localhost;user=root;password=;database=" & Me.database & ";allow user variables=true"

        conn = New MySqlConnection(connstr)
    End Sub

    Public Sub New()
        conn = New MySqlConnection("server=localhost;uid=root;pwd=;database=nilai_karyawan;allow user variables=true")
    End Sub

    Public Sub buka()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub

    Public Sub tutup()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Public Function getKoneksi() As MySqlConnection
        Return conn
    End Function

    Public Function isConnect() As Boolean
        If conn.State = ConnectionState.Open Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function getDatabaseName() As String
        Return Me.database
    End Function

    Public Function nonQuery(ByVal query As String) As Integer
        command = New MySqlCommand(query, conn)
        Return command.ExecuteNonQuery
    End Function

    Public Function generateId(ByVal suffix As String, ByVal tabel As String, ByVal kolom As String, ByVal num_length As Integer) As String
        Dim next_id = "1", id, gabung As String
        Dim zeroChar As String = "0000000"
        Dim count_row As Integer
        Dim query As String = "select count(*) from " & tabel
        command = New MySqlCommand(query, conn)
        reader = command.ExecuteReader
        While reader.Read
            count_row = reader(0)
        End While
        reader.Close()
        If count_row <> 0 Then
            query = "select max(right(" & kolom & ", " & Convert.ToString(num_length) & "))+1 from " & tabel
            command = New MySqlCommand(query, conn)
            reader = command.ExecuteReader
            While reader.Read
                next_id = reader(0)
            End While
        End If
        reader.Close()
        gabung = zeroChar + next_id
        id = suffix & gabung.Substring((gabung.Length - num_length), num_length)
        Return id
    End Function

    Public Sub isiDataGrid(ByVal datagridview As DataGridView, ByVal tabel As String)
        Dim query As String = "select * from " & tabel
        adapter = New MySqlDataAdapter(query, conn)
        dataset = New DataSet
        adapter.Fill(dataset, tabel)
        datagridview.DataSource = dataset.Tables(tabel)
    End Sub

    Public Sub queryDataGrid(ByVal datagridview As DataGridView, ByVal selectQuery As String)
        Dim query As String = selectQuery
        adapter = New MySqlDataAdapter(query, conn)
        dataset = New DataSet
        adapter.Fill(dataset, "Tabel")
        datagridview.DataSource = dataset.Tables("Tabel")
    End Sub

    Public Sub isiComboBox(ByVal combobox As ComboBox, ByVal tabel As String, ByVal valueMember As String, ByVal displayMember As String)
        Dim query As String = "select * from " & tabel
        adapter = New MySqlDataAdapter(query, conn)
        dataset = New DataSet
        adapter.Fill(dataset, tabel)
        combobox.DataSource = dataset.Tables(tabel)
        combobox.ValueMember = valueMember
        combobox.DisplayMember = displayMember
    End Sub

    Public Sub queryComboBox(ByVal combobox As ComboBox, ByVal query As String, ByVal tabel As String, ByVal valueMember As String, ByVal displayMember As String)
        adapter = New MySqlDataAdapter(query, conn)
        dataset = New DataSet
        adapter.Fill(dataset, tabel)
        combobox.DataSource = dataset.Tables(tabel)
        combobox.ValueMember = valueMember
        combobox.DisplayMember = displayMember
    End Sub
End Class
