
namespace PAP_C_DISP_TESTER
{
    public static class Constants
    {

        //作業者へのメッセージ
        public const string MessOperator = "作業者名を選択してください";
        public const string MessOpecode = "バーコードリーダーで工番を入力してください";
        public const string MessSet = "製品をセットしてください";
        public const string MessRemove = "製品を取り外してください";
        public const string MessWait = "検査中！　しばらくお待ちください・・・";
        public const string MessCheckConnectMachine = "周辺機器の接続を確認してください！";

        //Conf File
        public static readonly string RootPath = State.MachineName == "TSPCDP00059" ? @"D:\試験機用設定ファイル\PAP-C-DISP" : @"C:\PAP-C-DISP";
        public static readonly string filePath_TestSpec = $@"{RootPath}\ConfigData\TestSpec.config";
        public static readonly string filePath_Configuration = $@"{RootPath}\ConfigData\Configuration.config";
        public static readonly string filePath_Cam1Prop = $@"{RootPath}\ConfigData\Camera1Property.config";
        public static readonly string filePath_Cam2Prop = $@"{RootPath}\ConfigData\Camera2Property.config";
        public static readonly string filePath_Camera1CalFilePath = $@"{RootPath}\ConfigData\AN181100577.xml";
        public static readonly string filePath_Camera2CalFilePath = $@"{RootPath}\ConfigData\AN181100590.xml";


        public static readonly string Path_Manual = $@"{RootPath}\Manual.pdf";


        //検査データフォルダのパス
        public static readonly string PassDataPath = $@"{RootPath}\検査データ\合格品データ\";
        public static readonly string FailDataPath = $@"{RootPath}\検査データ\不合格品データ\";
        public static readonly string fileName_RetryLog = $@"{RootPath}\検査データ\リトライ履歴.txt";
        public static readonly string fileName_FormatPass = $@"{RootPath}\検査データ\FormatPass.csv";
        public static readonly string fileName_FormatFail = $@"{RootPath}\検査データ\FormatFail.csv";


        public const string Cmd_LD1a = "SR,0000,0200,0000,0001";
        public const string Cmd_LD1b = "SR,0000,0200,0000,0002";
        public const string Cmd_LD1c = "SR,0000,0200,0000,0004";
        public const string Cmd_LD1d = "SR,0000,0200,0000,0008";
        public const string Cmd_LD1e = "SR,0000,0200,0000,0010";
        public const string Cmd_LD1f = "SR,0000,0200,0000,0020";
        public const string Cmd_LD1g = "SR,0000,0200,0000,0040";
        public const string Cmd_LD1h = "SR,0000,0200,0000,0080";
        public const string Cmd_LD1i = "SR,0000,0200,0000,0100";
        public const string Cmd_LD1j = "SR,0000,0200,0000,0200";
        public const string Cmd_LD1k = "SR,0000,0200,0000,0400";
        public const string Cmd_LD1l = "SR,0000,0200,0000,0800";
        public const string Cmd_LD1m = "SR,0000,0200,0000,1000";
        public const string Cmd_LD1n = "SR,0000,0200,0000,2000";
        public const string Cmd_LD1p = "SR,0000,0200,0000,4000";

        public const string Cmd_LD2a = "SR,0000,0400,0000,0001";
        public const string Cmd_LD2b = "SR,0000,0400,0000,0002";
        public const string Cmd_LD2c = "SR,0000,0400,0000,0004";
        public const string Cmd_LD2d = "SR,0000,0400,0000,0008";
        public const string Cmd_LD2e = "SR,0000,0400,0000,0010";
        public const string Cmd_LD2f = "SR,0000,0400,0000,0020";
        public const string Cmd_LD2g = "SR,0000,0400,0000,0040";
        public const string Cmd_LD2h = "SR,0000,0400,0000,0080";
        public const string Cmd_LD2i = "SR,0000,0400,0000,0100";
        public const string Cmd_LD2j = "SR,0000,0400,0000,0200";
        public const string Cmd_LD2k = "SR,0000,0400,0000,0400";
        public const string Cmd_LD2l = "SR,0000,0400,0000,0800";
        public const string Cmd_LD2m = "SR,0000,0400,0000,1000";
        public const string Cmd_LD2n = "SR,0000,0400,0000,2000";
        public const string Cmd_LD2p = "SR,0000,0400,0000,4000";

        public const string Cmd_LD3a = "SR,0000,0800,0000,0001";
        public const string Cmd_LD3b = "SR,0000,0800,0000,0002";
        public const string Cmd_LD3c = "SR,0000,0800,0000,0004";
        public const string Cmd_LD3d = "SR,0000,0800,0000,0008";
        public const string Cmd_LD3e = "SR,0000,0800,0000,0010";
        public const string Cmd_LD3f = "SR,0000,0800,0000,0020";
        public const string Cmd_LD3g = "SR,0000,0800,0000,0040";
        public const string Cmd_LD3h = "SR,0000,0800,0000,0080";
        public const string Cmd_LD3i = "SR,0000,0800,0000,0100";
        public const string Cmd_LD3j = "SR,0000,0800,0000,0200";
        public const string Cmd_LD3k = "SR,0000,0800,0000,0400";
        public const string Cmd_LD3l = "SR,0000,0800,0000,0800";
        public const string Cmd_LD3m = "SR,0000,0800,0000,1000";
        public const string Cmd_LD3n = "SR,0000,0800,0000,2000";
        public const string Cmd_LD3p = "SR,0000,0800,0000,4000";

        public const string Cmd_LD4a = "SR,0000,1000,0000,0001";
        public const string Cmd_LD4b = "SR,0000,1000,0000,0002";
        public const string Cmd_LD4c = "SR,0000,1000,0000,0004";
        public const string Cmd_LD4d = "SR,0000,1000,0000,0008";
        public const string Cmd_LD4e = "SR,0000,1000,0000,0010";
        public const string Cmd_LD4f = "SR,0000,1000,0000,0020";
        public const string Cmd_LD4g = "SR,0000,1000,0000,0040";
        public const string Cmd_LD4h = "SR,0000,1000,0000,0080";
        public const string Cmd_LD4i = "SR,0000,1000,0000,0100";
        public const string Cmd_LD4j = "SR,0000,1000,0000,0200";
        public const string Cmd_LD4k = "SR,0000,1000,0000,0400";
        public const string Cmd_LD4l = "SR,0000,1000,0000,0800";
        public const string Cmd_LD4m = "SR,0000,1000,0000,1000";
        public const string Cmd_LD4n = "SR,0000,1000,0000,2000";
        public const string Cmd_LD4p = "SR,0000,1000,0000,4000";

        public const string Cmd_LD5a = "SR,0000,0100,0001,0000";
        public const string Cmd_LD5b = "SR,0000,0100,0002,0000";
        public const string Cmd_LD5c = "SR,0000,0100,0004,0000";
        public const string Cmd_LD5d = "SR,0000,0100,0008,0000";
        public const string Cmd_LD5e = "SR,0000,0100,0010,0000";
        public const string Cmd_LD5f = "SR,0000,0100,0020,0000";
        public const string Cmd_LD5g = "SR,0000,0100,0040,0000";
        public const string Cmd_LD5h = "SR,0000,0100,0080,0000";
        public const string Cmd_LD5i = "SR,0000,0100,0100,0000";
        public const string Cmd_LD5j = "SR,0000,0100,0200,0000";
        public const string Cmd_LD5k = "SR,0000,0100,0400,0000";
        public const string Cmd_LD5l = "SR,0000,0100,0800,0000";
        public const string Cmd_LD5m = "SR,0000,0100,1000,0000";
        public const string Cmd_LD5n = "SR,0000,0100,2000,0000";
        public const string Cmd_LD5p = "SR,0000,0100,4000,0000";

        public const string Cmd_LD6a = "SR,0000,0200,0001,0000";
        public const string Cmd_LD6b = "SR,0000,0200,0002,0000";
        public const string Cmd_LD6c = "SR,0000,0200,0004,0000";
        public const string Cmd_LD6d = "SR,0000,0200,0008,0000";
        public const string Cmd_LD6e = "SR,0000,0200,0010,0000";
        public const string Cmd_LD6f = "SR,0000,0200,0020,0000";
        public const string Cmd_LD6g = "SR,0000,0200,0040,0000";
        public const string Cmd_LD6h = "SR,0000,0200,0080,0000";
        public const string Cmd_LD6i = "SR,0000,0200,0100,0000";
        public const string Cmd_LD6j = "SR,0000,0200,0200,0000";
        public const string Cmd_LD6k = "SR,0000,0200,0400,0000";
        public const string Cmd_LD6l = "SR,0000,0200,0800,0000";
        public const string Cmd_LD6m = "SR,0000,0200,1000,0000";
        public const string Cmd_LD6n = "SR,0000,0200,2000,0000";
        public const string Cmd_LD6p = "SR,0000,0200,4000,0000";

        public const string Cmd_LD7a = "SR,0000,0400,0001,0000";
        public const string Cmd_LD7b = "SR,0000,0400,0002,0000";
        public const string Cmd_LD7c = "SR,0000,0400,0004,0000";
        public const string Cmd_LD7d = "SR,0000,0400,0008,0000";
        public const string Cmd_LD7e = "SR,0000,0400,0010,0000";
        public const string Cmd_LD7f = "SR,0000,0400,0020,0000";
        public const string Cmd_LD7g = "SR,0000,0400,0040,0000";
        public const string Cmd_LD7h = "SR,0000,0400,0080,0000";
        public const string Cmd_LD7i = "SR,0000,0400,0100,0000";
        public const string Cmd_LD7j = "SR,0000,0400,0200,0000";
        public const string Cmd_LD7k = "SR,0000,0400,0400,0000";
        public const string Cmd_LD7l = "SR,0000,0400,0800,0000";
        public const string Cmd_LD7m = "SR,0000,0400,1000,0000";
        public const string Cmd_LD7n = "SR,0000,0400,2000,0000";
        public const string Cmd_LD7p = "SR,0000,0400,4000,0000";

        public const string Cmd_LD8a = "SR,0000,0800,0001,0000";
        public const string Cmd_LD8b = "SR,0000,0800,0002,0000";
        public const string Cmd_LD8c = "SR,0000,0800,0004,0000";
        public const string Cmd_LD8d = "SR,0000,0800,0008,0000";
        public const string Cmd_LD8e = "SR,0000,0800,0010,0000";
        public const string Cmd_LD8f = "SR,0000,0800,0020,0000";
        public const string Cmd_LD8g = "SR,0000,0800,0040,0000";
        public const string Cmd_LD8h = "SR,0000,0800,0080,0000";
        public const string Cmd_LD8i = "SR,0000,0800,0100,0000";
        public const string Cmd_LD8j = "SR,0000,0800,0200,0000";
        public const string Cmd_LD8k = "SR,0000,0800,0400,0000";
        public const string Cmd_LD8l = "SR,0000,0800,0800,0000";
        public const string Cmd_LD8m = "SR,0000,0800,1000,0000";
        public const string Cmd_LD8n = "SR,0000,0800,2000,0000";
        public const string Cmd_LD8p = "SR,0000,0800,4000,0000";

        public const string Cmd_LD9a = "SR,0000,1000,0001,0000";
        public const string Cmd_LD9b = "SR,0000,1000,0002,0000";
        public const string Cmd_LD9c = "SR,0000,1000,0004,0000";
        public const string Cmd_LD9d = "SR,0000,1000,0008,0000";
        public const string Cmd_LD9e = "SR,0000,1000,0010,0000";
        public const string Cmd_LD9f = "SR,0000,1000,0020,0000";
        public const string Cmd_LD9g = "SR,0000,1000,0040,0000";
        public const string Cmd_LD9h = "SR,0000,1000,0080,0000";
        public const string Cmd_LD9i = "SR,0000,1000,0100,0000";
        public const string Cmd_LD9j = "SR,0000,1000,0200,0000";
        public const string Cmd_LD9k = "SR,0000,1000,0400,0000";
        public const string Cmd_LD9l = "SR,0000,1000,0800,0000";
        public const string Cmd_LD9m = "SR,0000,1000,1000,0000";
        public const string Cmd_LD9n = "SR,0000,1000,2000,0000";
        public const string Cmd_LD9p = "SR,0000,1000,4000,0000";

        public const string Cmd_LD10 = "SR,0000,0100,0000,0001";
        public const string Cmd_LD11 = "SR,0000,0100,0000,0002";
        public const string Cmd_LD12 = "SR,0000,0100,0000,0004";
        public const string Cmd_LD13 = "SR,0000,0100,0000,0008";
        public const string Cmd_LD14 = "SR,0000,0100,0000,0010";
        public const string Cmd_LD15 = "SR,0000,0100,0000,0020";


        //リトライ回数
        public static readonly int RetryCount = 0;

        //
        public static readonly double PanelOpacity = 0.4;

    }
}
