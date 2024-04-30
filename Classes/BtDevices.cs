using Shiny.BluetoothLE;

namespace MyNamespace.Classes {
   public class CBtDevices : IObserver<ScanResult> {
      public readonly List<CBtDevice> DeviceList = new();
      public readonly List<string> DeviceListStr = new();
      public readonly List<string> DeviceListUuid = new();
      public readonly Dictionary<string, CBtDevice> DeviceDict = new();
      public Peripheral SelectedDevice { get; set; }

      public CBtDevices() {
      }

      public void OnNext(ScanResult value) {
         if (!DeviceListUuid.Contains(value.Peripheral.Uuid)) {
            CBtDevice Device = new((Peripheral)value.Peripheral);
            DeviceDict.Add(value.Peripheral.Name, Device);
            DeviceList.Add(Device);
            DeviceListStr.Add(value.Peripheral.Name ?? "NULL");
            DeviceListUuid.Add(value.Peripheral.Uuid);
         }
      }
      public void OnCompleted() {
         Console.WriteLine("OnComplete.");
      }

      public void OnError(Exception error) {
         throw new NotImplementedException();
      }

      public CBtDevice GetDevice(string name) {
         return DeviceDict[name];
      }
   }
}
