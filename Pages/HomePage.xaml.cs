using MyNamespace.Classes;

namespace MyNamespace.Pages;

public partial class HomePage : ContentPage {
   private CBluetooth m_Bluetooth = new();
   private CBtDevice? Device;
   private CBtService? Service;
   private CBtCharacteristic? Characteristic;

   public HomePage() {
      InitializeComponent();
      btnScan.IsEnabled = true;
      btnStopScan.IsEnabled = false;
      btnConnect.IsEnabled = false;
      btnDisconnect.IsEnabled = false;
   }

   private async void OnScanButtonClicked(object sender, EventArgs e) {
      activityIndicator.IsRunning = true;
      activityIndicator.IsVisible = true;
      pkrDevice.Items.Clear();
      await m_Bluetooth.Scan();
      btnScan.IsEnabled = false;
      btnStopScan.IsEnabled =true;
      btnConnect.IsEnabled = true;
      activityIndicator.IsRunning = false;
      activityIndicator.IsVisible = false;
   }
   private void OnStopScanButtonClicked(object sender, EventArgs e) {
      m_Bluetooth.StopScan();
      btnScan.IsEnabled = true;
      btnStopScan.IsEnabled =false;
   }
   private void OnConnectButtonClicked(object sender, EventArgs e) {
      pkrDevice.ItemsSource = m_Bluetooth.BtDevices.DeviceListStr;
      btnDisconnect.IsEnabled = true;
      btnConnect.IsEnabled = false;
   }
   private void OnDisconnectButtonClicked(object sender, EventArgs e) {
      
      btnConnect.IsEnabled = true;
      btnDisconnect.IsEnabled = false;
      m_Bluetooth.DisconnectDevice();
   }
   private async void OnDeviceSelectedIndexChanged(object sender, EventArgs e) {
      vslView.IsEnabled = false;
      activityIndicator.IsRunning = true;
      activityIndicator.IsVisible = true;

      var picker = (Picker)sender;
      Device = m_Bluetooth.BtDevices.GetDevice(picker.SelectedItem.ToString());
      
      await m_Bluetooth.ConnectDevice(Device);
    
      await Device.Scan();
      pkrService.ItemsSource = Device.Services.ServiceListStr;
      activityIndicator.IsRunning = false;
      activityIndicator.IsVisible = false;
      vslView.IsEnabled = true;
   }
   private async void OnServiceSelectedIndexChanged(object sender, EventArgs e) {
      vslView.IsEnabled = false;
      activityIndicator.IsRunning = true;
      activityIndicator.IsVisible = true;
      var picker = (Picker)sender;
      Service = Device.Services.GetService(picker.SelectedItem.ToString());
      await Service.Scan(Device.Peripheral);
      pkrCharacteristic.ItemsSource = Service.Characteristics.CharacteristicListStr;
      activityIndicator.IsRunning = false;
      activityIndicator.IsVisible = false;
      vslView.IsEnabled = true;
   }

   private void OnCharacteristicSelectedIndexChanged(object sender, EventArgs e) {
      var picker = (Picker)sender;
      Characteristic = Service.Characteristics.GetCharacteristic(picker.SelectedItem.ToString());
   }

   void OnReadButtonClicked(object sender, EventArgs e) {
      UpdateRead();
   }
   void OnWriteButtonClicked(object sender, EventArgs e) {
      if (Characteristic == null) {
         return;
      }

      bool isNumeric = int.TryParse(editWriteValue.Text, out int n);
      if (isNumeric) {
         Characteristic.Write(BitConverter.GetBytes(n));
      }
      UpdateRead();
   }

   void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e) {
      if (e.Value) {
         Characteristic.Write(new byte[] { 1 });
      } else {
         Characteristic.Write(new byte[] { 0 });
      }
   }

   async void UpdateRead() {
      await Characteristic.Read();
      lblReadValue.Text = Characteristic.Value.ToString();
   }
}
