﻿namespace EECloud.PlayerIO
{
    public enum ErrorCode
    {
        UnsupportedMethod = 0,
        GeneralError = 1,
        InternalError = 2,
        AccessDenied = 3,
        InvalidMessageFormat = 4,
        MissingValue = 5,
        GameRequired = 6,
        ExternalError = 7,
        ArgumentOutOfRange = 8,
        GameDisabled = 9,
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
 