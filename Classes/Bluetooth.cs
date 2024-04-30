using Shiny;
using Shiny.BluetoothLE;
using System.Diagnostics;
using System.Reactive.Linq;

namespace MyNamespace.Classes {
   public class CBluetooth {
      /// <summary>
      /// BLE manager interfacte
      /// </summary>
      private readonly IBleManager? m_BleManager;
      private IPeripheral? m_Peripheral;

      public CBtDevices BtDevices = new();

      public CBluetooth() {
         m_BleManager = Shiny.Hosting.Host.GetService<IBleManager>();
      }
      ~CBluetooth() {
         // This will disconnect a current connection, cancel a connection attempt, and
         // remove persistent connections
         m_Peripheral?.CancelConnection();
      }

      public async Task Scan() {
         var tokenSource = new CancellationTokenSource();
         tokenSource.CancelAfter(TimeSpan.FromSeconds(5));
         if (m_BleManager == null) {
            return;
         }
         var access = await m_BleManager.RequestAccess();
         if (access != AccessState.Available) {
            return;
         }
         try {
            var stopwatch = Stopwatch.StartNew();
            var Scanner = m_BleManager.Scan(new ScanConfig(Constants.DeviceUuid));
            Scanner.Subscribe(BtDevices, tokenSource.Token);

            Console.WriteLine($"Elapsed time:          {stopwatch.Elapsed}\n");
         } catch (OperationCanceledException) {
            Console.WriteLine("Operation timed out.");
         } catch (Exception e) {
            Console.WriteLine(e.Message);
         }

      }

      /// <summary>
      /// Stops the scan
      /// </summary>
      public void StopScan() {
 //ToDo        m_Scanner?.Dispose();
      }

      /// <summary>
      /// Connects to a device
      /// </summary>
      /// <param></param>
      /// <returns></returns>
      public async Task ConnectDevice(CBtDevice Device) {
//TODO         await peripheral.Timeout(TimeSpan.FromSeconds(10)).WithConnectIf();
         await Device.Peripheral.ConnectAsync();
         m_Peripheral = Device.Peripheral;
      }

      /// <summary>
      /// Disconnects from a device
      /// </summary>
      public void DisconnectDevice() {
         m_Peripheral?.CancelConnection();
      }
   }
}
