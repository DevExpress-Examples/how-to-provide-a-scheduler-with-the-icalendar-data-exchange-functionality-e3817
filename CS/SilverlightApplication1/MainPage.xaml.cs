using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using DevExpress.XtraScheduler.iCalendar;

namespace SilverlightApplication1 {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }

        #region #Import_Button
        private void Import_Button_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "iCalendar files (*.ics)|*.ics";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() != true)
                return;

            using (Stream stream = dialog.File.OpenRead()) {
                ImportAppointments(stream);
            }
        }
        #endregion #Import_Button

        #region #Import_Drop
        private void schedulerControl1_Drop(object sender, DragEventArgs e) {
            FileInfo[] fileInfos = e.Data.GetData(DataFormats.FileDrop) as FileInfo[];
            if (fileInfos == null || fileInfos.Length == 0)
                return;

            foreach (FileInfo fileInfo in fileInfos) {
                if (fileInfo.Exists) {
                    using (Stream stream = fileInfo.OpenRead()) {
                        ImportAppointments(stream);
                    }
                }
            }
        }
        #endregion #Import_Drop

        #region #Import
        private void ImportAppointments(Stream stream) {
            schedulerControl1.Storage.AppointmentStorage.Clear();
            if (stream == null || Stream.Null.Equals(stream))
                return;
            iCalendarImporter importer = new iCalendarImporter(schedulerControl1.GetCoreStorage());
            importer.Import(stream);
        }
        #endregion #Import

        #region #Export
        private void Export_Button_Click(object sender, RoutedEventArgs e) {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "iCalendar files (*.ics)|*.ics";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true) {
                using (Stream stream = dialog.OpenFile()) {
                    ExportAppointments(stream);
                }
            }
        }
        void ExportAppointments(Stream stream) {
            if (stream == null || Stream.Null.Equals(stream))
                return;
            iCalendarExporter exporter = new iCalendarExporter(schedulerControl1.GetCoreStorage());
            exporter.ProductIdentifier = "-//Developer Express Inc.//DXScheduler iCalendarExchange Example//EN";
            exporter.Export(stream);
        }
        #endregion #Export


    }
}