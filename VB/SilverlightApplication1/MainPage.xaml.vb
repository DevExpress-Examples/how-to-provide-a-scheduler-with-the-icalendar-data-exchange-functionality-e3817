Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.XtraScheduler.iCalendar

Namespace SilverlightApplication1
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
            InitializeComponent()
		End Sub

#Region "#Import_Button"
        Private Sub Import_Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim dialog As New OpenFileDialog()
            dialog.Filter = "iCalendar files (*.ics)|*.ics"
            dialog.FilterIndex = 1
            If dialog.ShowDialog() <> True Then
                Return
            End If

            Using stream As Stream = dialog.File.OpenRead()
                ImportAppointments(stream)
            End Using
        End Sub
#End Region

#Region "#Import_Drop"
        Private Sub schedulerControl1_Drop(ByVal sender As Object, ByVal e As DragEventArgs)
            Dim fileInfos() As FileInfo = TryCast(e.Data.GetData(DataFormats.FileDrop), FileInfo())
            If fileInfos Is Nothing OrElse fileInfos.Length = 0 Then
                Return
            End If

            For Each fileInfo As FileInfo In fileInfos
                If fileInfo.Exists Then
                    Using stream As Stream = fileInfo.OpenRead()
                        ImportAppointments(stream)
                    End Using
                End If
            Next fileInfo
        End Sub
#End Region

#Region "#Import"
        Private Sub ImportAppointments(ByVal stream As Stream)
            schedulerControl1.Storage.AppointmentStorage.Clear()
            If stream Is Nothing OrElse stream.Null.Equals(stream) Then
                Return
            End If
            Dim importer As New iCalendarImporter(schedulerControl1.GetCoreStorage())
            importer.Import(stream)
        End Sub
#End Region

#Region "#Export"
        Private Sub Export_Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim dialog As New SaveFileDialog()
            dialog.Filter = "iCalendar files (*.ics)|*.ics"
            dialog.FilterIndex = 1
            If dialog.ShowDialog() = True Then
                Using stream As Stream = dialog.OpenFile()
                    ExportAppointments(stream)
                End Using
            End If
        End Sub
        Private Sub ExportAppointments(ByVal stream As Stream)
            If stream Is Nothing OrElse stream.Null.Equals(stream) Then
                Return
            End If
            Dim exporter As New iCalendarExporter(schedulerControl1.GetCoreStorage())
            exporter.ProductIdentifier = "-//Developer Express Inc.//DXScheduler iCalendarExchange Example//EN"
            exporter.Export(stream)
        End Sub
#End Region


	End Class
End Namespace

