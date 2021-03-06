using Newtonsoft.Json;
using PaZword.Api.Data;
using PaZword.Api.Models;
using PaZword.Core;
using PaZword.Core.Json;
using System;
using System.Security;
using System.Threading.Tasks;

namespace PaZword.Models.Data
{
    /// <summary>
    /// Represents the data associated to a Wi-Fi password.
    /// </summary>
    internal sealed class WiFiCredentialData : AccountData, IUpgradableAccountData
    {
        [SecurityCritical]
        [JsonProperty(nameof(Ssid))]
        [JsonConverter(typeof(SecureStringJsonConverter))]
        private SecureString _ssid;

        [SecurityCritical]
        [JsonProperty(nameof(Password))]
        [JsonConverter(typeof(SecureStringJsonConverter))]
        private SecureString _password;

        /// <summary>
        /// Gets or sets the Wi-Fi network name.
        /// </summary>
        [JsonIgnore]
        internal SecureString Ssid
        {
            get => EncryptionProvider.DecryptString(_ssid.ToUnsecureString(), string.Empty).ToSecureString();
            set => _ssid = EncryptionProvider.EncryptString(value.ToUnsecureString(disposeValue: true), string.Empty).ToSecureString();
        }

        /// <summary>
        /// Gets or sets the Wi-Fi passowrd.
        /// </summary>
        [JsonIgnore]
        internal SecureString Password
        {
            get => EncryptionProvider.DecryptString(_password.ToUnsecureString(), string.Empty).ToSecureString();
            set => _password = EncryptionProvider.EncryptString(value.ToUnsecureString(disposeValue: true), string.Empty).ToSecureString();
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="WiFiCredentialData"/> class.
        /// </summary>
        public WiFiCredentialData()
            : base()
        {
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="WiFiCredentialData"/> class.
        /// </summary>
        /// <param name="id">The unique ID of the account</param>
        internal WiFiCredentialData(Guid id)
            : base(id)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (IsDisposed)
            {
                return;
            }

            if (disposing)
            {
                _ssid?.Dispose();
                _password?.Dispose();
            }

            base.Dispose(disposing);
        }

        public override bool ExactEquals(AccountData other)
        {
            return
                other is WiFiCredentialData wifiCredentialData
                && wifiCredentialData.Id == Id
                && wifiCredentialData._ssid.IsEqualTo(_ssid)
                && wifiCredentialData._password.IsEqualTo(_password);
        }

        public Task UpgradeAsync(int oldVersion, int targetVersion)
        {
            if (oldVersion == 1)
            {
                // In Version 1, there was a vulnerability in the encryption engine.
                // Let's fix it by decrypting and re-encrypting all data.

#pragma warning disable CA2245 // Do not assign a property to itself.
                Ssid = Ssid;
                Password = Password;
#pragma warning restore CA2245 // Do not assign a property to itself.
            }

            return Task.CompletedTask;
        }
    }
}
