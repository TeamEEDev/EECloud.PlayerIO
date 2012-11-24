namespace EECloud.PlayerIO
{
    public enum ErrorCode
    {
        /// <summary>
        /// The method requested is not supported.
        /// </summary>
        UnsupportedMethod = 0,

        /// <summary>
        /// A general error has just occurred.
        /// </summary>
        GeneralError = 1,

        /// <summary>
        /// An unexpected error has just occurred inside the Player.IO WebService. Please try again later.
        /// </summary>
        InternalError = 2,

        /// <summary>
        /// The content you've just wanted to access is not available for you.
        /// </summary>
        AccessDenied = 3,

        /// <summary>
        /// The message is malformatted.
        /// </summary>
        InvalidMessageFormat = 4,

        /// <summary>
        /// A value is missing.
        /// </summary>
        MissingValue = 5,

        /// <summary>
        /// A game is required to do this action.
        /// </summary>
        GameRequired = 6,

        /// <summary>
        /// An error has just occurred while communicating with an external service.
        /// </summary>
        ExternalError = 7,

        /// <summary>
        /// The given argument value is outside the range of allowed values.
        /// </summary>
        ArgumentOutOfRange = 8,

        /// <summary>
        /// 
        /// </summary>
        GameDisabled = 9,


        InvalidType = 80,


        IndexOutOfBounds = 81,


        UnknownGame = 10,


        UnknownConnection = 11,


        InvalidAuth = 12,


        NoAvailableServers = 13,


        RoomDataTooLarge = 14,
      
        
        RoomAlreadyExists = 15,
        
        
        UnknownServerType = 16,
        
        
        UnknownRoom = 17,
        
        
        MissingRoomId = 18,
        
        
        RoomIsFull = 19,
        
        
        NotASearchColumn = 20,
        
        
        QuickConnectMethodNotEnabled = 21,
        
        
        UnknownUser = 22,
        
        
        InvalidPassword = 23,
        
        
        InvalidRegistrationData = 24,
        
        
        InvalidBigDBKey = 25,
        
        
        BigDBObjectTooLarge = 26,
        
        
        BigDBObjectDoesNotExist = 27,
        
        
        UnknownTable = 28,
        
        
        UnknownIndex = 29,
        
        
        InvalidIndexValue = 30,
        
        
        NotObjectCreator = 31,
        
        
        KeyAlreadyUsed = 32,
        
        
        StaleVersion = 33,
        
        
        CircularReference = 34,
        
        
        VaultNotLoaded = 50,
        
        
        UnknownPayVaultProvider = 51,
        
        
        DirectPurchaseNotSupportedByProvider = 52,
        
        
        BuyingCoinsNotSupportedByProvider = 54,
        
        
        NotEnoughCoins = 55
    }
}
