using System.Runtime.InteropServices;

namespace SoLoud.Interop;

ref struct RefSoloud {}
ref struct RefAudioSource {}
ref struct RefFilter {}
ref struct RefAudioCollider {}
ref struct RefAudioAttenuator {}
ref struct RefAy {}
ref struct RefQueue {}
ref struct RefWav {}
ref struct RefWavStream {}
ref struct RefBus {}

internal static unsafe partial class SoloudInterop
{
	private const string DLL_NAME = "./dll/soloud_x64.dll";
	
	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_destroy(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern RefSoloud* Soloud_create();

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_init(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_initEx(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aFlags, [NativeTypeName("unsigned int")] uint aBackend, [NativeTypeName("unsigned int")] uint aSamplerate, [NativeTypeName("unsigned int")] uint aBufferSize, [NativeTypeName("unsigned int")] uint aChannels);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_pause(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_resume(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_deinit(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_getVersion(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("const char *")]
	public static extern sbyte* Soloud_getErrorString(RefSoloud* aSoloud, int aErrorCode);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_getBackendId(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("const char *")]
	public static extern sbyte* Soloud_getBackendString(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_getBackendChannels(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_getBackendSamplerate(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_getBackendBufferSize(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_setSpeakerPosition(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aChannel, float aX, float aY, float aZ);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_getSpeakerPosition(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aChannel, float* aX, float* aY, float* aZ);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_play(RefSoloud* aSoloud, RefAudioSource* aSound);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_playEx(RefSoloud* aSoloud, RefAudioSource* aSound, float aVolume, float aPan, int aPaused, [NativeTypeName("unsigned int")] uint aBus);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_playClocked(RefSoloud* aSoloud, double aSoundTime, RefAudioSource* aSound);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_playClockedEx(RefSoloud* aSoloud, double aSoundTime, RefAudioSource* aSound, float aVolume, float aPan, [NativeTypeName("unsigned int")] uint aBus);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_play3d(RefSoloud* aSoloud, RefAudioSource* aSound, float aPosX, float aPosY, float aPosZ);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_play3dEx(RefSoloud* aSoloud, RefAudioSource* aSound, float aPosX, float aPosY, float aPosZ, float aVelX, float aVelY, float aVelZ, float aVolume, int aPaused, [NativeTypeName("unsigned int")] uint aBus);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_play3dClocked(RefSoloud* aSoloud, double aSoundTime, RefAudioSource* aSound, float aPosX, float aPosY, float aPosZ);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_play3dClockedEx(RefSoloud* aSoloud, double aSoundTime, RefAudioSource* aSound, float aPosX, float aPosY, float aPosZ, float aVelX, float aVelY, float aVelZ, float aVolume, [NativeTypeName("unsigned int")] uint aBus);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_playBackground(RefSoloud* aSoloud, RefAudioSource* aSound);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_playBackgroundEx(RefSoloud* aSoloud, RefAudioSource* aSound, float aVolume, int aPaused, [NativeTypeName("unsigned int")] uint aBus);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_seek(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, double aSeconds);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_stop(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_stopAll(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_stopAudioSource(RefSoloud* aSoloud, RefAudioSource* aSound);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_countAudioSource(RefSoloud* aSoloud, RefAudioSource* aSound);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setFilterParameter(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, [NativeTypeName("unsigned int")] uint aFilterId, [NativeTypeName("unsigned int")] uint aAttributeId, float aValue);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern float Soloud_getFilterParameter(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, [NativeTypeName("unsigned int")] uint aFilterId, [NativeTypeName("unsigned int")] uint aAttributeId);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_fadeFilterParameter(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, [NativeTypeName("unsigned int")] uint aFilterId, [NativeTypeName("unsigned int")] uint aAttributeId, float aTo, double aTime);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_oscillateFilterParameter(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, [NativeTypeName("unsigned int")] uint aFilterId, [NativeTypeName("unsigned int")] uint aAttributeId, float aFrom, float aTo, double aTime);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern double Soloud_getStreamTime(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern double Soloud_getStreamPosition(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_getPause(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern float Soloud_getVolume(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern float Soloud_getOverallVolume(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern float Soloud_getPan(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern float Soloud_getSamplerate(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_getProtectVoice(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_getActiveVoiceCount(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_getVoiceCount(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_isValidVoiceHandle(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern float Soloud_getRelativePlaySpeed(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern float Soloud_getPostClipScaler(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_getMainResampler(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern float Soloud_getGlobalVolume(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_getMaxActiveVoiceCount(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_getLooping(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_getAutoStop(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern double Soloud_getLoopPoint(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setLoopPoint(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, double aLoopPoint);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setLooping(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, int aLooping);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setAutoStop(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, int aAutoStop);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_setMaxActiveVoiceCount(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceCount);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setInaudibleBehavior(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, int aMustTick, int aKill);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setGlobalVolume(RefSoloud* aSoloud, float aVolume);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setPostClipScaler(RefSoloud* aSoloud, float aScaler);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setMainResampler(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aResampler);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setPause(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, int aPause);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setPauseAll(RefSoloud* aSoloud, int aPause);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_setRelativePlaySpeed(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, float aSpeed);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setProtectVoice(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, int aProtect);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setSamplerate(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, float aSamplerate);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setPan(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, float aPan);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setPanAbsolute(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, float aLVolume, float aRVolume);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setChannelVolume(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, [NativeTypeName("unsigned int")] uint aChannel, float aVolume);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setVolume(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, float aVolume);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setDelaySamples(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, [NativeTypeName("unsigned int")] uint aSamples);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_fadeVolume(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, float aTo, double aTime);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_fadePan(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, float aTo, double aTime);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_fadeRelativePlaySpeed(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, float aTo, double aTime);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_fadeGlobalVolume(RefSoloud* aSoloud, float aTo, double aTime);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_schedulePause(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, double aTime);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_scheduleStop(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, double aTime);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_oscillateVolume(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, float aFrom, float aTo, double aTime);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_oscillatePan(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, float aFrom, float aTo, double aTime);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_oscillateRelativePlaySpeed(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, float aFrom, float aTo, double aTime);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_oscillateGlobalVolume(RefSoloud* aSoloud, float aFrom, float aTo, double aTime);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setGlobalFilter(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aFilterId, RefFilter* aFilter);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_setVisualizationEnable(RefSoloud* aSoloud, int aEnable);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern float* Soloud_calcFFT(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern float* Soloud_getWave(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern float Soloud_getApproximateVolume(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aChannel);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_getLoopCount(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern float Soloud_getInfo(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, [NativeTypeName("unsigned int")] uint aInfoKey);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Soloud_createVoiceGroup(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_destroyVoiceGroup(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceGroupHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_addVoiceToGroup(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceGroupHandle, [NativeTypeName("unsigned int")] uint aVoiceHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_isVoiceGroup(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceGroupHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_isVoiceGroupEmpty(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceGroupHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_update3dAudio(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Soloud_set3dSoundSpeed(RefSoloud* aSoloud, float aSpeed);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern float Soloud_get3dSoundSpeed(RefSoloud* aSoloud);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_set3dListenerParameters(RefSoloud* aSoloud, float aPosX, float aPosY, float aPosZ, float aAtX, float aAtY, float aAtZ, float aUpX, float aUpY, float aUpZ);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_set3dListenerParametersEx(RefSoloud* aSoloud, float aPosX, float aPosY, float aPosZ, float aAtX, float aAtY, float aAtZ, float aUpX, float aUpY, float aUpZ, float aVelocityX, float aVelocityY, float aVelocityZ);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_set3dListenerPosition(RefSoloud* aSoloud, float aPosX, float aPosY, float aPosZ);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_set3dListenerAt(RefSoloud* aSoloud, float aAtX, float aAtY, float aAtZ);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_set3dListenerUp(RefSoloud* aSoloud, float aUpX, float aUpY, float aUpZ);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_set3dListenerVelocity(RefSoloud* aSoloud, float aVelocityX, float aVelocityY, float aVelocityZ);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_set3dSourceParameters(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, float aPosX, float aPosY, float aPosZ);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_set3dSourceParametersEx(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, float aPosX, float aPosY, float aPosZ, float aVelocityX, float aVelocityY, float aVelocityZ);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_set3dSourcePosition(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, float aPosX, float aPosY, float aPosZ);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_set3dSourceVelocity(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, float aVelocityX, float aVelocityY, float aVelocityZ);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_set3dSourceMinMaxDistance(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, float aMinDistance, float aMaxDistance);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_set3dSourceAttenuation(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, [NativeTypeName("unsigned int")] uint aAttenuationModel, float aAttenuationRolloffFactor);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_set3dSourceDopplerFactor(RefSoloud* aSoloud, [NativeTypeName("unsigned int")] uint aVoiceHandle, float aDopplerFactor);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_mix(RefSoloud* aSoloud, float* aBuffer, [NativeTypeName("unsigned int")] uint aSamples);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Soloud_mixSigned16(RefSoloud* aSoloud, short* aBuffer, [NativeTypeName("unsigned int")] uint aSamples);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Ay_destroy(RefAy* aAy);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern RefAy* Ay_create();

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Ay_setVolume(RefAy* aAy, float aVolume);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Ay_setLooping(RefAy* aAy, int aLoop);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Ay_setAutoStop(RefAy* aAy, int aAutoStop);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Ay_set3dMinMaxDistance(RefAy* aAy, float aMinDistance, float aMaxDistance);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Ay_set3dAttenuation(RefAy* aAy, [NativeTypeName("unsigned int")] uint aAttenuationModel, float aAttenuationRolloffFactor);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Ay_set3dDopplerFactor(RefAy* aAy, float aDopplerFactor);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Ay_set3dListenerRelative(RefAy* aAy, int aListenerRelative);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Ay_set3dDistanceDelay(RefAy* aAy, int aDistanceDelay);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Ay_set3dCollider(RefAy* aAy, RefAudioCollider* aCollider);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Ay_set3dColliderEx(RefAy* aAy, RefAudioCollider* aCollider, int aUserData);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Ay_set3dAttenuator(RefAy* aAy, RefAudioAttenuator* aAttenuator);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Ay_setInaudibleBehavior(RefAy* aAy, int aMustTick, int aKill);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Ay_setLoopPoint(RefAy* aAy, double aLoopPoint);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern double Ay_getLoopPoint(RefAy* aAy);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Ay_setFilter(RefAy* aAy, [NativeTypeName("unsigned int")] uint aFilterId, RefFilter* aFilter);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Ay_stop(RefAy* aAy);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Queue_destroy(RefQueue* aQueue);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern RefQueue* Queue_create();

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Queue_play(RefQueue* aQueue, RefAudioSource* aSound);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Queue_getQueueCount(RefQueue* aQueue);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Queue_isCurrentlyPlaying(RefQueue* aQueue, RefAudioSource* aSound);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Queue_setParamsFromAudioSource(RefQueue* aQueue, RefAudioSource* aSound);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Queue_setParams(RefQueue* aQueue, float aSamplerate);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Queue_setParamsEx(RefQueue* aQueue, float aSamplerate, [NativeTypeName("unsigned int")] uint aChannels);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Queue_setVolume(RefQueue* aQueue, float aVolume);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Queue_setLooping(RefQueue* aQueue, int aLoop);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Queue_setAutoStop(RefQueue* aQueue, int aAutoStop);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Queue_set3dMinMaxDistance(RefQueue* aQueue, float aMinDistance, float aMaxDistance);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Queue_set3dAttenuation(RefQueue* aQueue, [NativeTypeName("unsigned int")] uint aAttenuationModel, float aAttenuationRolloffFactor);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Queue_set3dDopplerFactor(RefQueue* aQueue, float aDopplerFactor);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Queue_set3dListenerRelative(RefQueue* aQueue, int aListenerRelative);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Queue_set3dDistanceDelay(RefQueue* aQueue, int aDistanceDelay);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Queue_set3dCollider(RefQueue* aQueue, RefAudioCollider* aCollider);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Queue_set3dColliderEx(RefQueue* aQueue, RefAudioCollider* aCollider, int aUserData);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Queue_set3dAttenuator(RefQueue* aQueue, RefAudioAttenuator* aAttenuator);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Queue_setInaudibleBehavior(RefQueue* aQueue, int aMustTick, int aKill);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Queue_setLoopPoint(RefQueue* aQueue, double aLoopPoint);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern double Queue_getLoopPoint(RefQueue* aQueue);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Queue_setFilter(RefQueue* aQueue, [NativeTypeName("unsigned int")] uint aFilterId, RefFilter* aFilter);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Queue_stop(RefQueue* aQueue);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Wav_destroy(RefWav* aWav);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern RefWav* Wav_create();

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
	public static extern int Wav_load(RefWav* aWav, [NativeTypeName("const char *")] string aFilename);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Wav_loadMem(RefWav* aWav, [NativeTypeName("const unsigned char *")] byte* aMem, [NativeTypeName("unsigned int")] uint aLength);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Wav_loadMemEx(RefWav* aWav, [NativeTypeName("const unsigned char *")] byte* aMem, [NativeTypeName("unsigned int")] uint aLength, int aCopy, int aTakeOwnership);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Wav_loadFile(RefWav* aWav, [NativeTypeName("File *")] void** aFile);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Wav_loadRawWave8(RefWav* aWav, [NativeTypeName("unsigned char *")] byte* aMem, [NativeTypeName("unsigned int")] uint aLength);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Wav_loadRawWave8Ex(RefWav* aWav, [NativeTypeName("unsigned char *")] byte* aMem, [NativeTypeName("unsigned int")] uint aLength, float aSamplerate, [NativeTypeName("unsigned int")] uint aChannels);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Wav_loadRawWave16(RefWav* aWav, short* aMem, [NativeTypeName("unsigned int")] uint aLength);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Wav_loadRawWave16Ex(RefWav* aWav, short* aMem, [NativeTypeName("unsigned int")] uint aLength, float aSamplerate, [NativeTypeName("unsigned int")] uint aChannels);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Wav_loadRawWave(RefWav* aWav, float* aMem, [NativeTypeName("unsigned int")] uint aLength);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Wav_loadRawWaveEx(RefWav* aWav, float* aMem, [NativeTypeName("unsigned int")] uint aLength, float aSamplerate, [NativeTypeName("unsigned int")] uint aChannels, int aCopy, int aTakeOwnership);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern double Wav_getLength(RefWav* aWav);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Wav_setVolume(RefWav* aWav, float aVolume);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Wav_setLooping(RefWav* aWav, int aLoop);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Wav_setAutoStop(RefWav* aWav, int aAutoStop);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Wav_set3dMinMaxDistance(RefWav* aWav, float aMinDistance, float aMaxDistance);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Wav_set3dAttenuation(RefWav* aWav, [NativeTypeName("unsigned int")] uint aAttenuationModel, float aAttenuationRolloffFactor);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Wav_set3dDopplerFactor(RefWav* aWav, float aDopplerFactor);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Wav_set3dListenerRelative(RefWav* aWav, int aListenerRelative);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Wav_set3dDistanceDelay(RefWav* aWav, int aDistanceDelay);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Wav_set3dCollider(RefWav* aWav, RefAudioCollider* aCollider);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Wav_set3dColliderEx(RefWav* aWav, RefAudioCollider* aCollider, int aUserData);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Wav_set3dAttenuator(RefWav* aWav, RefAudioAttenuator* aAttenuator);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Wav_setInaudibleBehavior(RefWav* aWav, int aMustTick, int aKill);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Wav_setLoopPoint(RefWav* aWav, double aLoopPoint);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern double Wav_getLoopPoint(RefWav* aWav);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Wav_setFilter(RefWav* aWav, [NativeTypeName("unsigned int")] uint aFilterId, RefFilter* aFilter);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Wav_stop(RefWav* aWav);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void WavStream_destroy(RefWavStream* aWavStream);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern RefWavStream* WavStream_create();

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int WavStream_load(RefWavStream* aWavStream, [NativeTypeName("const char *")] sbyte* aFilename);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int WavStream_loadMem(RefWavStream* aWavStream, [NativeTypeName("const unsigned char *")] byte* aData, [NativeTypeName("unsigned int")] uint aDataLen);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int WavStream_loadMemEx(RefWavStream* aWavStream, [NativeTypeName("const unsigned char *")] byte* aData, [NativeTypeName("unsigned int")] uint aDataLen, int aCopy, int aTakeOwnership);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int WavStream_loadToMem(RefWavStream* aWavStream, [NativeTypeName("const char *")] sbyte* aFilename);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int WavStream_loadFile(RefWavStream* aWavStream, [NativeTypeName("File *")] void** aFile);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int WavStream_loadFileToMem(RefWavStream* aWavStream, [NativeTypeName("File *")] void** aFile);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern double WavStream_getLength(RefWavStream* aWavStream);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void WavStream_setVolume(RefWavStream* aWavStream, float aVolume);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void WavStream_setLooping(RefWavStream* aWavStream, int aLoop);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void WavStream_setAutoStop(RefWavStream* aWavStream, int aAutoStop);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void WavStream_set3dMinMaxDistance(RefWavStream* aWavStream, float aMinDistance, float aMaxDistance);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void WavStream_set3dAttenuation(RefWavStream* aWavStream, [NativeTypeName("unsigned int")] uint aAttenuationModel, float aAttenuationRolloffFactor);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void WavStream_set3dDopplerFactor(RefWavStream* aWavStream, float aDopplerFactor);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void WavStream_set3dListenerRelative(RefWavStream* aWavStream, int aListenerRelative);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void WavStream_set3dDistanceDelay(RefWavStream* aWavStream, int aDistanceDelay);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void WavStream_set3dCollider(RefWavStream* aWavStream, RefAudioCollider* aCollider);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void WavStream_set3dColliderEx(RefWavStream* aWavStream, RefAudioCollider* aCollider, int aUserData);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void WavStream_set3dAttenuator(RefWavStream* aWavStream, RefAudioAttenuator* aAttenuator);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void WavStream_setInaudibleBehavior(RefWavStream* aWavStream, int aMustTick, int aKill);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void WavStream_setLoopPoint(RefWavStream* aWavStream, double aLoopPoint);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern double WavStream_getLoopPoint(RefWavStream* aWavStream);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void WavStream_setFilter(RefWavStream* aWavStream, [NativeTypeName("unsigned int")] uint aFilterId, RefFilter* aFilter);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void WavStream_stop(RefWavStream* aWavStream);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_destroy(RefBus* aBus);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern RefBus* Bus_create();

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_setFilter(RefBus* aBus, [NativeTypeName("unsigned int")] uint aFilterId, RefFilter* aFilter);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Bus_play(RefBus* aBus, RefAudioSource* aSound);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Bus_playEx(RefBus* aBus, RefAudioSource* aSound, float aVolume, float aPan, int aPaused);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Bus_playClocked(RefBus* aBus, double aSoundTime, RefAudioSource* aSound);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Bus_playClockedEx(RefBus* aBus, double aSoundTime, RefAudioSource* aSound, float aVolume, float aPan);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Bus_play3d(RefBus* aBus, RefAudioSource* aSound, float aPosX, float aPosY, float aPosZ);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Bus_play3dEx(RefBus* aBus, RefAudioSource* aSound, float aPosX, float aPosY, float aPosZ, float aVelX, float aVelY, float aVelZ, float aVolume, int aPaused);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Bus_play3dClocked(RefBus* aBus, double aSoundTime, RefAudioSource* aSound, float aPosX, float aPosY, float aPosZ);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Bus_play3dClockedEx(RefBus* aBus, double aSoundTime, RefAudioSource* aSound, float aPosX, float aPosY, float aPosZ, float aVelX, float aVelY, float aVelZ, float aVolume);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int Bus_setChannels(RefBus* aBus, [NativeTypeName("unsigned int")] uint aChannels);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_setVisualizationEnable(RefBus* aBus, int aEnable);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_annexSound(RefBus* aBus, [NativeTypeName("unsigned int")] uint aVoiceHandle);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern float* Bus_calcFFT(RefBus* aBus);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern float* Bus_getWave(RefBus* aBus);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern float Bus_getApproximateVolume(RefBus* aBus, [NativeTypeName("unsigned int")] uint aChannel);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Bus_getActiveVoiceCount(RefBus* aBus);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	[return: NativeTypeName("unsigned int")]
	public static extern uint Bus_getResampler(RefBus* aBus);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_setResampler(RefBus* aBus, [NativeTypeName("unsigned int")] uint aResampler);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_setVolume(RefBus* aBus, float aVolume);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_setLooping(RefBus* aBus, int aLoop);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_setAutoStop(RefBus* aBus, int aAutoStop);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_set3dMinMaxDistance(RefBus* aBus, float aMinDistance, float aMaxDistance);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_set3dAttenuation(RefBus* aBus, [NativeTypeName("unsigned int")] uint aAttenuationModel, float aAttenuationRolloffFactor);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_set3dDopplerFactor(RefBus* aBus, float aDopplerFactor);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_set3dListenerRelative(RefBus* aBus, int aListenerRelative);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_set3dDistanceDelay(RefBus* aBus, int aDistanceDelay);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_set3dCollider(RefBus* aBus, RefAudioCollider* aCollider);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_set3dColliderEx(RefBus* aBus, RefAudioCollider* aCollider, int aUserData);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_set3dAttenuator(RefBus* aBus, RefAudioAttenuator* aAttenuator);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_setInaudibleBehavior(RefBus* aBus, int aMustTick, int aKill);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_setLoopPoint(RefBus* aBus, double aLoopPoint);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern double Bus_getLoopPoint(RefBus* aBus);

	[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void Bus_stop(RefBus* aBus);
}
