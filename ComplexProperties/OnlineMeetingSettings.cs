// ---------------------------------------------------------------------------
// <copyright file="OnlineMeetingSettings.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------

//-----------------------------------------------------------------------
// <summary>Defines the OnlineMeetingSettings class.</summary>
//-----------------------------------------------------------------------

namespace Microsoft.Exchange.WebServices.Data
{
    /// <summary>
    /// Online Meeting Lobby Bypass options.
    /// </summary>
    public enum LobbyBypass
    {
        /// <summary>
        /// Disabled.
        /// </summary>
        Disabled,

        /// <summary>
        /// Enabled for gateway participants.
        /// </summary>
        EnabledForGatewayParticipants,
    }

    /// <summary>
    /// Online Meeting Access Level options.
    /// </summary>
    public enum OnlineMeetingAccessLevel
    {
        /// <summary>
        /// Locked.
        /// </summary>
        Locked,

        /// <summary>
        /// Invited.
        /// </summary>
        Invited,

        /// <summary>
        /// Internal.
        /// </summary>
        Internal,

        /// <summary>
        /// Everyone.
        /// </summary>
        Everyone,
    }

    /// <summary>
    /// Online Meeting Presenters options.
    /// </summary>
    public enum Presenters
    {
        /// <summary>
        /// Disabled.
        /// </summary>
        Disabled,

        /// <summary>
        /// Internal.
        /// </summary>
        Internal,

        /// <summary>
        /// Everyone.
        /// </summary>
        Everyone,
    }
    
    /// <summary>
    /// Represents Lync online meeting settings.
    /// </summary>
    public class OnlineMeetingSettings : ComplexProperty
    {
        /// <summary>
        /// Email address.
        /// </summary>
        private LobbyBypass lobbyBypass;

        /// <summary>
        /// Routing type.
        /// </summary>
        private OnlineMeetingAccessLevel accessLevel;

        /// <summary>
        /// Routing type.
        /// </summary>
        private Presenters presenters;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="OnlineMeetingSettings"/> class.
        /// </summary>
        public OnlineMeetingSettings()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnlineMeetingSettings"/> class.
        /// </summary>
        /// <param name="lobbyBypass">The address used to initialize the OnlineMeetingSettings.</param>
        /// <param name="accessLevel">The routing type used to initialize the OnlineMeetingSettings.</param>
        /// <param name="presenters">Mailbox type of the participant.</param>
        internal OnlineMeetingSettings(
            LobbyBypass lobbyBypass,
            OnlineMeetingAccessLevel accessLevel,
            Presenters presenters)
        {
            this.lobbyBypass = lobbyBypass;
            this.accessLevel = accessLevel;
            this.presenters = presenters;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnlineMeetingSettings"/> class from another OnlineMeetingSettings instance.
        /// </summary>
        /// <param name="onlineMeetingSettings">OnlineMeetingSettings instance to copy.</param>
        internal OnlineMeetingSettings(OnlineMeetingSettings onlineMeetingSettings)
            : this()
        {
            EwsUtilities.ValidateParam(onlineMeetingSettings, "OnlineMeetingSettings");

            this.LobbyBypass = onlineMeetingSettings.LobbyBypass;
            this.AccessLevel = onlineMeetingSettings.AccessLevel;
            this.Presenters = onlineMeetingSettings.Presenters;
        }

        /// <summary>
        /// Gets or sets the online meeting setting that describes whether users dialing in by phone have to wait in the lobby.
        /// </summary>
        public LobbyBypass LobbyBypass
        {
            get
            {
                return this.lobbyBypass;
            }

            set
            {
                this.SetFieldValue<LobbyBypass>(ref this.lobbyBypass, value);
            }
        }

        /// <summary>
        /// Gets or sets the online meeting setting that describes access permission to the meeting.
        /// </summary>
        public OnlineMeetingAccessLevel AccessLevel
        {
            get
            {
                return this.accessLevel;
            }

            set
            {
                this.SetFieldValue<OnlineMeetingAccessLevel>(ref this.accessLevel, value);
            }
        }

        /// <summary>
        /// Gets or sets the online meeting setting that defines the meeting leaders.
        /// </summary>
        public Presenters Presenters
        {
            get
            {
                return this.presenters;
            }

            set
            {
                this.SetFieldValue<Presenters>(ref this.presenters, value);
            }
        }

        /// <summary>
        /// Tries to read element from XML.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>True if element was read.</returns>
        internal override bool TryReadElementFromXml(EwsServiceXmlReader reader)
        {
            switch (reader.LocalName)
            {
                case XmlElementNames.LobbyBypass:
                    this.lobbyBypass = reader.ReadElementValue<LobbyBypass>();
                    return true;
                case XmlElementNames.AccessLevel:
                    this.accessLevel = reader.ReadElementValue<OnlineMeetingAccessLevel>();
                    return true;
                case XmlElementNames.Presenters:
                    this.presenters = reader.ReadElementValue<Presenters>();
                    return true;
                default:
                    return false;
            }
        }
        
        /// <summary>
        /// Writes elements to XML.
        /// </summary>
        /// <param name="writer">The writer.</param>
        internal override void WriteElementsToXml(EwsServiceXmlWriter writer)
        {
            writer.WriteElementValue(XmlNamespace.Types, XmlElementNames.LobbyBypass, this.LobbyBypass);
            writer.WriteElementValue(XmlNamespace.Types, XmlElementNames.AccessLevel, this.AccessLevel);
            writer.WriteElementValue(XmlNamespace.Types, XmlElementNames.Presenters, this.Presenters);
        }
    }
}
