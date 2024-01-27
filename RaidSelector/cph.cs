using Streamer.bot.Common.Events;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System;
using Twitch.Common.Models;
using Twitch.Common.Models.Api;
using EventSource = Streamer.bot.Common.Events.EventSource;

namespace CPHNameSpace
{
    /************************************************************************
     * DO NOT USE - PLACEHOLDER CLASS
     ************************************************************************/
#pragma warning disable IDE0060
    public static class CPH
    {
        // General
        public static int Between(int min, int max) { return 0; }
        public static double NextDouble() { return 0; }
        public static void Wait(int milliseconds) { }
        public static string UrlEncode(string text) { return ""; }
        public static string EscapeString(string text) { return ""; }
        public static EventSource GetSource() { return default; }
        public static EventType GetEventType() { return default; }
        public static bool RunAction(string actionName, bool runImmediately = true) { return false; }
        public static bool RunActionById(string actionId, bool runImmediately = true) { return false; }
        public static void DisableAction(string actionName) { }
        public static void EnableAction(string actionName) { }
        public static bool ActionExists(string actionName) { return false; }
        public static void PauseActionQueue(string name) { }
        public static void PauseAllActionQueues() { }
        public static void ResumeActionQueue(string name, bool clear = false) { }
        public static void ResumeAllActionQueues(bool clear = false) { }
        public static void PlaySound(string fileName, float volume = 1.0f, bool finishBeforeContinuing = false) { }
        public static void PlaySoundFromFolder(string path, float volume = 1.0f, bool recursive = false, bool finishBeforeContinuing = false) { }
        public static void KeyboardPress(string keyPress) { }
        public static bool ExecuteMethod(string executeCode, string methodName) { return false; }
        public static void LogInfo(string logLine) { }
        public static void LogWarn(string logLine) { }
        public static void LogDebug(string logLine) { }
        public static void LogVerbose(string logLine) { }
        public static void AddToCredits(string section, string value, bool json = true) { }
        public static void ResetCredits() { }
        public static void ResetFirstWords() { }
        public static void DisableTimer(string timerName) { }
        public static void EnableTimer(string timerName) { }
        public static void SetArgument(string variableName, object value) { }
        public static T? GetGlobalVar<T>(string varName, bool persisted = true) { return default; }
        public static T? GetUserVar<T>(string userName, string varName, bool persisted = true) { return default; }
        public static void SetGlobalVar(string varName, object value, bool persisted = true) { }
        public static void SetUserVar(string userName, string varName, object value, bool persisted = true) { }
        public static void UnsetGlobalVar(string varName, bool persisted = true) { }
        public static void UnsetUserVar(string userName, string varName, bool persisted = true) { }
        public static void UnsetUser(string userName, bool persisted = true) { }
        public static bool UserInGroup(int userId, string groupName) { return false; }
        public static bool UserInGroup(string userName, string groupName) { return false; }
        public static bool AddUserToGroup(int userId, string groupName) { return false; }
        public static bool AddUserToGroup(string userName, string groupName) { return false; }
        public static bool RemoveUserFromGroup(int userId, string groupName) { return false; }
        public static bool RemoveUserFromGroup(string userName, string groupName) { return false; }
        public static void EnableCommand(string id) { }
        public static void DisableCommand(string id) { }
        public static void CommandSetGlobalCooldownDuration(string id, int seconds) { }
        public static void CommandSetUserCooldownDuration(string id, int seconds) { }
        public static void CommandAddToGlobalCooldown(string id, int seconds) { }
        public static void CommandAddToUserCooldown(string id, int userId, int seconds) { }
        public static void CommandAddToAllUserCooldowns(string id, int seconds) { }
        public static void CommandResetGlobalCooldown(string id) { }
        public static void CommandResetUserCooldown(string id, int userId) { }
        public static void CommandResetAllUserCooldowns(string id) { }


        // Servers and Clients
        public static void WebsocketBroadcastString(string data) { }
        public static void WebsocketBroadcastJson(string data) { }
        public static void WebsocketConnect(int connection = 0) { }
        public static void WebsocketDisconnect(int connection = 0) { }
        public static bool WebsocketIsConnected(int connection = 0) { return false; }
        public static void WebsocketSend(string data, int connection = 0) { }
        public static void WebsocketSend(byte[] data, int connection = 0) { }
        public static void WebsocketCustomServerStart(int connection = 0) { }
        public static void WebsocketCustomServerStop(int connection = 0) { }
        public static bool WebsocketCustomServerIsListening(int connection = 0) { return false; }
        public static void WebsocketCustomServerCloseAllSessions(int connection = 0) { }
        public static void WebsocketCustomServerCloseSession(string sessionId, int connection = 0) { }
        public static void WebsocketCustomServerBroadcast(string data, string sessionId, int connection = 0) { }
        public static int WebsocketCustomServerGetConnectionByName(string name) { return 0; }
        public static int BroadcastUdp(int port, object data) { return 0; }


        // Twitch
#pragma warning disable CA2211 // Non-constant fields should not be visible
        public static string? Id;

        public static string? Url;
        public static string? EmbedUrl;
        public static int BroadcasterId;
        public static string? BroadcasterName;
        public static int CreatorId;
        public static string? CreatorName;
        public static string? VideoId;
        public static string? GameId;
        public static string? Language;
        public static string? Title;
        public static int ViewCount;
        public static DateTime CreatedAt;
        public static string? ThumbnailUrl;
        public static float Duration;

        public static string? TwitchOAuthToken;
        public static string? TwitchClientId;
#pragma warning restore CA2211 // Non-constant fields should not be visible

        public class StreamMarker
        {
            public static int Id { get; set; }
            public static DateTime CreatedAt { get; set; }
            public static string? Description { get; set; }
            public static int Position { get; set; }
        }

        public static void SendMessage(string message, bool bot = true) { }
        public static void SendAction(string action, bool bot = true) { }
        public static List<Cheermote>? GetCheermotes() { return default; }
        public static void TwitchSubscriberOnly(bool enabled = true) { }
        public static void TwitchEmoteOnly(bool enabled = true) { }
        public static bool SendWhisper(string userName, string message) { return false; }
        public static bool TwitchAddModerator(string userName) { return false; }
        public static bool TwitchRemoveModerator(string userName) { return false; }
        public static bool TwitchAddVip(string userName) { return false; }
        public static bool TwitchRemoveVip(string userName) { return false; }
        public static bool TwitchClearChatMessages(bool bot = true) { return false; }
        public static bool TwitchDeleteChatMessage(string messageId, bool bot = true) { return false; }
        public static bool TwitchBanUser(string userName, string? reason = null, bool bot = false) { return false; }
        public static bool TwitchUnbanUser(string userName, bool bot = false) { return false; }
        public static void TimeoutUser(string userName, int duration) { }
        public static void DisableReward(string rewardId) { }
        public static void EnableReward(string rewardId) { }
        public static void PauseReward(string rewardId) { }
        public static void UnPauseReward(string rewardId) { }
        public static void UpdateRewardCost(string rewardId, int cost, bool additive = false) { }
        public static void UpdateRewardCooldown(string rewardId, int cooldown, bool additive = false) { }
        public static bool TwitchRedemptionFulfill(string rewardId, string redemptionId) { return false; }
        public static bool TwitchRedemptionCancel(string rewardId, string redemptionId) { return false; }
        public static bool UpdateRewardTitle(string rewardId, string title) { return false; }
        public static bool UpdateRewardPrompt(string rewardId, string prompt) { return false; }
        public static bool UpdateReward(string rewardId, string? title = null, string? prompt = null, int? cost = null) { return false; }
        public static bool TwitchPollCreate(string title, List<string> choices, int duration, int channelPointsPerVote = 0) { return false; }
        public static void TwitchPollTerminate(string pollId) { }
        public static void TwitchPollArchive(string pollId) { }
        public static string TwitchPredictionCreate(string title, List<string> options, int duration) { return ""; }
        public static void TwitchPredictionCancel(string predictionId) { }
        public static void TwitchPredictionLock(string predictionId) { }
        public static void TwitchPredictionResolve(string predictionId, string winningId) { }
        public static List<ClipData>? GetAllClips() { return default; }
        public static List<ClipData>? GetClipsForGame(int gameId) { return default; }
        public static List<ClipData>? GetClipsForUser(int userId) { return default; }
        public static List<ClipData>? GetClipsForUser(string username) { return default; }
        public static ClipData? CreateClip() { return default; }
        public static List<ClipData>? GetClipsForUser(int userId, int count) { return default; }
        public static List<ClipData>? GetClipsForUser(int userId, DateTime start, DateTime end) { return default; }
        public static List<ClipData>? GetClipsForUser(int userId, DateTime start, DateTime end, int count) { return default; }
        public static List<ClipData>? GetClipsForUser(int userId, TimeSpan duration) { return default; }
        public static List<ClipData>? GetClipsForUser(int userId, TimeSpan duration, int count) { return default; }
        public static List<ClipData>? GetClipsForUser(string userName, int count) { return default; }
        public static List<ClipData>? GetClipsForUser(string username, DateTime start, DateTime end) { return default; }
        public static List<ClipData>? GetClipsForUser(string username, DateTime start, DateTime end, int count) { return default; }
        public static List<ClipData>? GetClipsForUser(string username, TimeSpan duration) { return default; }
        public static List<ClipData>? GetClipsForUser(string username, TimeSpan duration, int count) { return default; }
        public static List<ClipData>? GetClipsForGame(int gameId, int count) { return default; }
        public static List<ClipData>? GetClipsForGame(int gameId, DateTime start, DateTime end) { return default; }
        public static List<ClipData>? GetClipsForGame(int gameId, DateTime start, DateTime end, int count) { return default; }
        public static List<ClipData>? GetClipsForGame(int gameId, TimeSpan duration) { return default; }
        public static List<ClipData>? GetClipsForGame(int gameId, TimeSpan duration, int count) { return default; }
        public static StreamMarker? CreateStreamMarker(string description) { return default; }
        public static void TwitchRunCommercial(int duration) { }
        public static void TwitchSlowMode(bool enabled = true, int duration = 0) { }
        public static bool SetChannelTitle(string title) { return false; }
        public static GameInfo? SetChannelGame(string game) { return default; }
        public static bool SetChannelGameById(string gameId) { return false; }
        public static void TwitchAnnounce(string message, bool bot = false, string? color = null) { }
        public static T? GetTwitchUserVar<T>(string userName, string varName, bool persisted = true) { return default; }
        public static void SetTwitchUserVar(string userName, string varName, object value, bool persisted = true) { }
        public static void UnsetTwitchUserVar(string userName, string varName, bool persisted = true) { }
        public static void UnsetTwitchUser(string userName, bool persisted = true) { }


        // Youtube
        public static void SendYouTubeMessage(string message) { }
        public static T? GetYouTubeUserVar<T>(string userName, string varName, bool persisted = true) { return default; }
        public static void SetYouTubeUserVar(string userName, string varName, object value, bool persisted = true) { }
        public static void UnsetYouTubeUserVar(string userName, string varName, bool persisted = true) { }
        public static void UnsetYouTubeUser(string userName, bool persisted = true) { }

        // OBS
        public static bool ObsIsConnected(int connection = 0) { return false; }
        public static bool ObsConnect(int connection = 0) { return false; }
        public static void ObsDisconnect(int connection = 0) { }
        public static bool ObsIsStreaming(int connection = 0) { return false; }
        public static void ObsStopStreaming(int connection = 0) { }
        public static bool ObsIsRecording(int connection = 0) { return false; }
        public static void ObsStartRecording(int connection = 0) { }
        public static void ObsStopRecording(int connection = 0) { }
        public static void ObsPauseRecording(int connection = 0) { }
        public static void ObsResumeRecording(int connection = 0) { }
        public static void ObsSetScene(string sceneName, int connection = 0) { }
        public static string ObsGetCurrentScene(int connection = 0) { return ""; }
        public static bool ObsIsSourceVisible(string scene, string source, int connection = 0) { return false; }
        public static void ObsSetSourceVisibility(string scene, string source, bool visible, int connection = 0) { }
        public static void ObsShowSource(string scene, string source, int connection = 0) { }
        public static void ObsHideSource(string scene, string source, int connection = 0) { }
        public static void ObsHideGroupsSources(string scene, string groupName, int connection = 0) { }
        public static string ObsSetRandomGroupSourceVisible(string scene, string groupName, int connection = 0) { return ""; }
        public static List<string>? ObsGetGroupSources(string scene, string groupName, int connection = 0) { return default; }
        public static string ObsGetSceneItemProperties(string scene, string source, int connection = 0) { return ""; }
        public static void ObsSetBrowserSource(string scene, string source, string url, int connection = 0) { }
        public static void ObsSetGdiText(string scene, string source, string text, int connection = 0) { }
        public static bool ObsIsFilterEnabled(string scene, string filterName, int connection = 0) { return false; }
        public static bool ObsIsFilterEnabled(string scene, string source, string filterName, int connection = 0) { return false; }
        public static void ObsSetFilterState(string scene, string filterName, int state, int connection = 0) { }
        public static void ObsSetFilterState(string scene, string source, string filterName, int state, int connection = 0) { }
        public static void ObsShowFilter(string scene, string filterName, int connection = 0) { }
        public static void ObsShowFilter(string scene, string source, string filterName, int connection = 0) { }
        public static void ObsHideFilter(string scene, string filterName, int connection = 0) { }
        public static void ObsHideFilter(string scene, string source, string filterName, int connection = 0) { }
        public static void ObsToggleFilter(string scene, string filterName, int connection = 0) { }
        public static void ObsToggleFilter(string scene, string source, string filterName, int connection = 0) { }
        public static void ObsSetRandomFilterState(string scene, int state, int connection = 0) { }
        public static void ObsSetRandomFilterState(string scene, string source, int state, int connection = 0) { }
        public static void ObsSetSourceMuteState(string scene, string source, int state, int connection = 0) { }
        public static void ObsSourceMute(string scene, string source, string filterName, int connection = 0) { }
        public static void ObsSourceUnMute(string scene, string source, string filterName, int connection = 0) { }
        public static void ObsSourceMuteToggle(string scene, string source, string filterName, int connection = 0) { }
        public static string ObsSendRaw(string requestType, string data, int connection = 0) { return ""; }
        public static void ObsHideSourcesFilters(string scene, string source, int connection = 0) { }
        public static void ObsHideScenesFilters(string scene, int connection = 0) { }
        public static void ObsSetMediaState(string scene, string source, int state, int connection = 0) { }
        public static void ObsMediaPlay(string scene, string source, int connection = 0) { }
        public static void ObsMediaPause(string scene, string source, int connection = 0) { }
        public static void ObsMediaRestart(string scene, string source, int connection = 0) { }
        public static void ObsMediaStop(string scene, string source, int connection = 0) { }
        public static void ObsMediaNext(string scene, string source, int connection = 0) { }
        public static void ObsMediaPrevious(string scene, string source, int connection = 0) { }
        public static long ObsConvertRgb(int a, int r, int g, int b) { return 0; }
        public static long ObsConvertColorHex(string colorHex) { return 0; }
        public static void ObsSetColorSourceColor(string scene, string source, int a, int r, int g, int b, int connection = 0) { }
        public static void ObsSetColorSourceColor(string scene, string source, string hexColor, int connection = 0) { }
        public static void ObsSetColorSourceRandomColor(string scene, string source, int connection = 0) { }
        public static int ObsGetConnectionByName(string name) { return 0; }
        public static void ObsSetReplayBufferState(int state, int connection = 0) { }
        public static void ObsReplayBufferStart(int connection = 0) { }
        public static void ObsReplayBufferStop(int connection = 0) { }
        public static void ObsReplayBufferSave(int connection = 0) { }
        public static void ObsSetMediaSourceFile(string scene, string source, string file, int connection = 0) { }
        public static void ObsSetImageSourceFile(string scene, string source, string file, int connection = 0) { }
        public static bool ObsTakeScreenshot(string scene, string source, string path, int quality = -1, int connection = 0) { return false; }

        // StreamLabs
        public static bool SlobsIsConnected(int connection = 0) { return false; }
        public static bool SlobsConnect(int connection = 0) { return false; }
        public static void SlobsDisconnect(int connection = 0) { }
        public static bool SlobsIsStreaming(int connection = 0) { return false; }
        public static void SlobsStopStreaming(int connection = 0) { }
        public static void SlobsStartStreaming(int connection = 0) { }
        public static bool SlobsIsRecording(int connection = 0) { return false; }
        public static void SlobsStartRecording(int connection = 0) { }
        public static void SlobsStopRecording(int connection = 0) { }
        public static void SlobsPauseRecording(int connection = 0) { }
        public static void SlobsResumeRecording(int connection = 0) { }
        public static void SlobsSetScene(string sceneName, int connection = 0) { }
        public static string SlobsGetCurrentScene(int connection = 0) { return ""; }
        public static bool SlobsIsSourceVisible(string scene, string source, int connection = 0) { return false; }
        public static void SlobsSetSourceVisibility(string scene, string source, bool visible, int connection = 0) { }
        public static void SlobsShowSource(string scene, string source, int connection = 0) { }
        public static void SlobsHideSource(string scene, string source, int connection = 0) { }
        public static void SlobsHideGroupsSources(string scene, string groupName, int connection = 0) { }
        public static string SlobsSetRandomGroupSourceVisible(string scene, string groupName, int connection = 0) { return ""; }
        public static List<string>? SlobsGetGroupSources(string scene, string groupName, int connection = 0) { return default; }
        public static void SlobsSetBrowserSource(string scene, string source, string url, int connection = 0) { }
        public static void SlobsSetGdiText(string scene, string source, string text, int connection = 0) { }
        public static bool SlobsIsFilterEnabled(string scene, string filterName, int connection = 0) { return false; }
        public static bool SlobsIsFilterEnabled(string scene, string source, string filterName, int connection = 0) { return false; }
        public static void SlobsSetFilterState(string scene, string filterName, int state, int connection = 0) { }
        public static void SlobsSetFilterState(string scene, string source, string filterName, int state, int connection = 0) { }
        public static void SlobsShowFilter(string scene, string filterName, int connection = 0) { }
        public static void SlobsShowFilter(string scene, string source, string filterName, int connection = 0) { }
        public static void SlobsHideFilter(string scene, string filterName, int connection = 0) { }
        public static void SlobsHideFilter(string scene, string source, string filterName, int connection = 0) { }
        public static void SlobsToggleFilter(string scene, string filterName, int connection = 0) { }
        public static void SlobsToggleFilter(string scene, string source, string filterName, int connection = 0) { }
        public static void SlobsSetRandomFilterState(string scene, int state, int connection = 0) { }
        public static void SlobsSetRandomFilterState(string scene, string source, int state, int connection = 0) { }
        public static void SlobsSetSourceMuteState(string scene, string source, int state, int connection = 0) { }
        public static void SlobsSourceMute(string scene, string source, string filterName, int connection = 0) { }
        public static void SlobsSourceUnMute(string scene, string source, string filterName, int connection = 0) { }
        public static void SlobsSourceMuteToggle(string scene, string source, string filterName, int connection = 0) { }

        // TwitchSpeaker
        public static int TtsSpeak(string voiceAlias, string message, bool badWordFilter = false) { return 0; }

        // VoiceMod
        public static void VoiceModSelectVoice(string voiceId) { }
        public static bool VoiceModVoiceChangerOn() { return false; }
        public static bool VoiceModVoiceChangerOff() { return false; }
        public static bool VoiceModHearMyVoiceOn() { return false; }
        public static bool VoiceModHearMyVoiceOff() { return false; }
        public static void VoiceModCensorOn() { }
        public static void VoiceModCensorOff() { }
        public static string VoiceModGetCurrentVoice() { return ""; }
        public static bool VoiceModGetVoiceChangerStatus() { return false; }
        public static bool VoiceModGetHearMyselfStatus() { return false; }

        // Lumia Stream
        public static void LumiaSetToDefault() { }
        public static void LumiaSendCommand(string command) { }

        // Discord
        public static bool DiscordPostTextToWebhook(string webhookUrl, string content, string? username = null, bool textToSpeech = false) { return false; }
    }
#pragma warning restore IDE0060
}