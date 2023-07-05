using System;
using System.Runtime.InteropServices;


namespace Monitor;

public partial class ProtocolHandler
{
    //All these functions are imported from "chai.dll" 
    //and their name starts with "Can"
    
    //#1
    ///<summary>
    /// Initialize CAN channel
    ///</summary>
    [DllImport("chai.dll", CharSet = CharSet.Unicode, EntryPoint = "CiInit")]
    private static extern short CanInitialize();
    
    //#2
    ///<summary>
    /// open channel.
    /// It may cause issues if CAN is unavailable
    ///</summary>
    [DllImport("chai.dll", CharSet = CharSet.Unicode, EntryPoint = "CiOpen")]
    private static extern short CanOpen(byte channel, byte flags);
    
    //#3
    ///<summary>
    /// close channel
    ///</summary>
    [DllImport("chai.dll", CharSet = CharSet.Unicode, EntryPoint = "CiClose")]
    private static extern short CanClose(byte channel);
    
    //#4

    [DllImport("chai.dll", CharSet = CharSet.Unicode, EntryPoint = "CiStart")]
    private static extern short CanStart(byte channel);
    
    //#5
    
    [DllImport("chai.dll", CharSet = CharSet.Unicode, EntryPoint = "CiStop")]
    private static extern short CanStop(byte channel);
    
    //#6

    [DllImport("chai.dll", CharSet = CharSet.Unicode, EntryPoint = "CiSetFilter")]
    private static extern short CanSetFilter(byte channel, UInt32 aCode, UInt32 aMask);
    
    //#7
    
    [DllImport("chai.dll", CharSet = CharSet.Unicode, EntryPoint = "CiSetBaud")]
    private static extern short CanSetBaud(byte channel, byte bt0, byte bt1);
    
    //#8
    
    [DllImport("chai.dll", CharSet = CharSet.Unicode, EntryPoint = "CiWrite")]
    private static extern unsafe short CanWrite(byte channel, canMessage* buffer, canMessage count);
    
    //#9
    
    
    [DllImport("chai.dll", CharSet = CharSet.Unicode, EntryPoint = "CiTransmit")]
    private static extern unsafe short CanTransmit(byte channel, canMessage* buffer);
    
    //#10
    
    [DllImport("chai.dll", CharSet = CharSet.Unicode, EntryPoint = "CiTrCancel")]
    private static extern unsafe short CanTransmitCancel(byte channel, UInt16* count);
    
    //#11
    
    [DllImport("chai.dll", CharSet = CharSet.Unicode, EntryPoint = "CiTrStat")]
    private static extern unsafe short CanTransmitStatistic(byte channel, UInt16* count);
    
    //#12
    
    [DllImport("chai.dll", CharSet = CharSet.Unicode, EntryPoint = "CiRead")]
    private static extern unsafe short CanRead(byte channel, canMessage* buffer, UInt16 count);
    
    //#13
    
    [DllImport("chai.dll", CharSet = CharSet.Unicode, EntryPoint = "CiErrsGetClear")]
    private static extern unsafe short CanErrorsGetClear(byte channel, canErrors* errors);
    
    //#14
    
    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint = "CiWaitEvent")]
    private static extern unsafe short CanWaitEvent(CanWait* canWait, int cwCount, int timeOut);
    
    //#15

    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiTrQueThreshold")]
    private static extern unsafe short CanTransmitQueueThreshold(byte channel, UInt16 getset, UInt16* threshold);
    
    //#16
    
    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiRcQueThreshold")]
    private static extern unsafe short CanChangeQueueThreshold(byte channel, UInt16 getset, UInt16* threshold);
    
    //#17
    
    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiRcQueResize")]
    private static extern short CanChangeQueueResize(byte channel, UInt16 size);
    
    
    //#18
    
    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiRcQueCancel")]
    private static extern unsafe short CanChangeQueueCancel(byte channel,UInt16* countPointer);
    
    //#19

    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiRcQueGetCnt")]

    private static extern unsafe short CanChangeQueueGetCount(byte channel, UInt16* countPointer);
    
    
    //#20 юбилей

    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiBoardGetSerial")]
    private static extern unsafe short CanBoardGetSerial(byte boardNumber, char* buffer, UInt16 bufferSize);
    
    //#21
    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiHwReset")]
    private static extern short CanReset(byte channel);
    
    //#22

    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiSetLom")]
    private static extern short CanSetLom(byte channel, byte mode);
    
    //#23

    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiWriteTout")]
    private static extern unsafe short CanWriteTimeOut(byte channel, UInt16 getset, UInt16* seconds);

    //#24
    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiGetLibVer")]
    private static extern UInt32 CanGetLibraryVersion();

    //#25
    
    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiGetDrvVer")]
    private static extern UInt32 CanGetDriverVersion();

    
    //#26
    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiChipStat")]
    private static extern unsafe short CanChipStatus(byte channel, ChipStatus* chipStatistics);

    
    //#27
    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiChipStatToStr")]
    private static extern unsafe short CanChipStatusToString(ChipStatus* status, ChipStatusDescription* description);

    
    //#28
    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiBoardInfo")]
    private static extern unsafe short CanBoardInfo(CanBoard* canBoard);
    
    
    //#29

    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiStrError")]
    private static extern unsafe void CanStringError(short canErrorNumber,char* buffer, short bufferLength);

    
    //#30
    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiPerror")]
    private static extern unsafe void CanPrintError(short CanErrorNumber, char* message);
    
    //#31
    //declared, but cannot be used(not sure; try it)
    
    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiSetCB")]
    private static extern unsafe short CanSetCB(byte channel, byte events, delegate*<short> CanHandler);
    
    //#32
    //declared, but cannot be used. Do not even try. I'm 100% sure it will occur many problems
    
    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiSetCBex")]
    private static extern unsafe short CanSetCallBackEx(byte channel, byte events,
        delegate*<byte, short, void*> canCallBackEX, void* udata);


    //#33
    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiCB_lock")]
    private static extern short CanCallBackLock();
    
    
    //#34
    [DllImport("chai.dll",CharSet = CharSet.Unicode, EntryPoint =  "CiCB_unlock")]
    private static extern short CanCallBackUnlock();


}