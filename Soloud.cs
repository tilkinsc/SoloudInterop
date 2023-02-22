using System.Numerics;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using SoLoud.Interop;

namespace SoLoud;

public enum SoloudBackendType
{
	Auto = 0,
	SDL1,
	SDL2,
	PortAudio,
	WinMM,
	XAudio2,
	WASAPI,
	ALSA,
	Jack,
	OSS,
	OpenAL,
	CoreAudio,
	OpenSLES,
	VitaHomebrew,
	MiniAudio,
	NoSound,
	NullDriver,
	BackendMax
}

public enum SoloudResultType
{
	None = 0,
	InvalidParameter = 1,
	FileNotFound = 2,
	FileLoadFailed = 3,
	DllNotFound = 4,
	OutOfMemory = 5,
	NotImplemented = 6,
	Unknown = 7
}

[Flags]
public enum SoloudFlag
{
	ClipRoundoff = 1,
	EnableVisualization = 2,
	LeftHanded3d = 4,
	NoFpuRegisterChange = 8
}

[Flags]
public enum AudioSourceInstanceFlag
{
	Looping = 1,
	Protected = 2,
	Paused = 4,
	Process3d = 8,
	ListenerRelative = 16,
	Inaudible = 32,
	InaudibleKill = 64,
	InaudibleTick = 128,
	DisableAutostop = 256
}

[Flags]
public enum AudioSourceFlag
{
	ShouldLoop = 1,
	SingleInstance = 2,
	VisualizationData = 4,
	Process3d = 8,
	ListenerRelative = 16,
	DistanceDleay = 32,
	InaudibleKill = 64,
	InaudibleTick = 128,
	DisableAutostop = 256
}

public enum WaveFormType
{
	Square = 0,
	Saw,
	Sin,
	Triangle,
	Bounce,
	Jaws,
	Humps,
	FSquare,
	FSaw
}

public enum ResamplerType
{
	Point = 0,
	Linear = 1,
	CatmullRom = 2
}

public enum AttenuationModelType
{
	None = 0,
	InverseDistance,
	LinearDistance,
	ExponentialDistance
}

public enum FilterParamType
{
	Float = 0,
	Int,
	Bool
}

/// <summary>
/// An internal safe wrapper for a Souloud object not resident in managed memory.
/// It's safe; it allows implementing code to know if the handle is valid.
/// It's smart; it introduces reliable cleanup.
/// It's robust; it type-safely implements how the stored pointer decays
/// for lower level generics.
/// </summary>
internal sealed unsafe class SafeSoloudContext : SafeHandleZeroOrMinusOneIsInvalid
{
	internal SafeSoloudContext(IntPtr ptr)
			: base(true)
	{
		SetHandle(ptr);
	}
	
	internal RefSoloud* Acquire() => (RefSoloud*) DangerousGetHandle();
	public static implicit operator RefSoloud*(SafeSoloudContext ctx) => (RefSoloud*) ctx.Acquire();
	
	protected override bool ReleaseHandle()
	{
		SoloudInterop.Soloud_destroy((RefSoloud*) this.handle);
		return true;
	}
}

/// <summary>
/// An internal safe wrapper for a Souloud object not resident in managed memory.
/// It's safe; it allows implementing code to know if the handle is valid.
/// It's smart; it introduces reliable cleanup.
/// It's robust; it type-safely implements how the stored pointer decays
/// for lower level generics.
/// </summary>
internal sealed unsafe class SafeWavContext : SafeHandleZeroOrMinusOneIsInvalid
{
	internal SafeWavContext(IntPtr ptr)
			: base(true)
	{
		SetHandle(ptr);
	}
	
	internal RefWav* Acquire() => (RefWav*) DangerousGetHandle();
	public static implicit operator RefAudioSource*(SafeWavContext ctx) => (RefAudioSource*) ctx.Acquire();
	public static implicit operator RefWav*(SafeWavContext ctx) => (RefWav*) ctx.Acquire();
	
	protected override bool ReleaseHandle()
	{
		SoloudInterop.Wav_destroy((RefWav*) this.handle);
		return true;
	}
}

/// <summary>
/// An internal safe wrapper for a Souloud object not resident in managed memory.
/// It's safe; it allows implementing code to know if the handle is valid.
/// It's smart; it introduces reliable cleanup.
/// It's robust; it type-safely implements how the stored pointer decays
/// for lower level generics.
/// </summary>
internal sealed unsafe class SafeWavStreamContext : SafeHandleZeroOrMinusOneIsInvalid
{
	internal SafeWavStreamContext(IntPtr ptr)
			: base(true)
	{
		SetHandle(ptr);
	}
	
	internal RefWavStream* Acquire() => (RefWavStream*) DangerousGetHandle();
	public static implicit operator RefAudioSource*(SafeWavStreamContext ctx) => (RefAudioSource*) ctx.Acquire();
	public static implicit operator RefWavStream*(SafeWavStreamContext ctx) => (RefWavStream*) ctx.Acquire();
	
	protected override bool ReleaseHandle()
	{
		SoloudInterop.WavStream_destroy((RefWavStream*) this.handle);
		return true;
	}
}

/// <summary>
/// An internal safe wrapper for a Souloud object not resident in managed memory.
/// It's safe; it allows implementing code to know if the handle is valid.
/// It's smart; it introduces reliable cleanup.
/// It's robust; it type-safely implements how the stored pointer decays
/// for lower level generics.
/// </summary>
internal sealed unsafe class SafeAyContext : SafeHandleZeroOrMinusOneIsInvalid
{
	internal SafeAyContext(IntPtr ptr)
			: base(true)
	{
		SetHandle(ptr);
	}
	
	internal RefAy* Acquire() => (RefAy*) DangerousGetHandle();
	public static implicit operator RefAy*(SafeAyContext ctx) => (RefAy*) ctx.Acquire();
	
	protected override bool ReleaseHandle()
	{
		SoloudInterop.Ay_destroy((RefAy*) this.handle);
		return true;
	}
}

/// <summary>
/// An internal safe wrapper for a Souloud object not resident in managed memory.
/// It's safe; it allows implementing code to know if the handle is valid.
/// It's smart; it introduces reliable cleanup.
/// It's robust; it type-safely implements how the stored pointer decays
/// for lower level generics.
/// </summary>
internal sealed unsafe class SafeBusContext : SafeHandleZeroOrMinusOneIsInvalid
{
	internal SafeBusContext(IntPtr ptr)
			: base(true)
	{
		SetHandle(ptr);
	}
	
	internal RefBus* Acquire() => (RefBus*) DangerousGetHandle();
	public static implicit operator RefBus*(SafeBusContext ctx) => (RefBus*) ctx.Acquire();
	
	protected override bool ReleaseHandle()
	{
		SoloudInterop.Bus_destroy((RefBus*) this.handle);
		return true;
	}
}

/// <summary>
/// A voice handle is a Soloud internal voice handle.
/// It is weak because the internal handle can be cleaned up at any time.
/// It is proper to check if a handle is valid before using it.
/// By default, a voice handle will become invalid when the it has stopped.
/// </summary>
public class VoiceHandle
{
	private Soloud _ctx;
	internal readonly uint Handle;
	
	public VoiceHandle(Soloud ctx, uint handle)
	{
		_ctx = ctx;
		Handle = handle;
	}
	
	public bool IsValidVoiceHandle()
	{
		return _ctx.IsValidVoiceHandle(this);
	}
}

/// <summary>
/// A voice handle is a Soloud internal voice handle.
/// It is termed weak because the internal handle can be cleaned up at any time.
/// It is proper to check if a handle is valid before using it.
/// By default, a voice handle will become invalid when the it has stopped.
/// </summary>
public class BusHandle
{
	private Bus _ctx;
	internal readonly uint Handle;
	
	public BusHandle(Bus ctx, uint handle)
	{
		_ctx = ctx;
		Handle = handle;
	}
}

public sealed unsafe class Soloud : IDisposable
{
	private bool _disposed;
	
	public bool IsDisposed => _disposed;
	
	/// <summary>
	/// Safely retrieves handle to the unmanaged state.
	/// See also: <see cref="SafeSoloudContext" />
	/// </summary>
	/// <exception cref="ObjectDisposedException">Thrown on attempt to access while invalid state.</exception>
	private SafeSoloudContext _handle;
	internal SafeSoloudContext Handle
	{
		get
		{
			ThrowIfDisposed();
			return _handle;
		}
	}
	
	public Soloud()
	{
		RefSoloud* ctx = SoloudInterop.Soloud_create();
		_handle = new SafeSoloudContext((IntPtr) ctx);
	}
	
	public Soloud(bool autoinit)
			: this()
	{
		if (autoinit)
		{
			Init();
		}
	}
	
	public void Dispose()
	{
		Handle.Dispose();
		_disposed = true;
	}
	
	public void ThrowIfDisposed()
	{
		if (_disposed || _handle.IsInvalid)
			throw new ObjectDisposedException(GetType().FullName, "Attempt to use Soloud when it's cleaned up.");
	}
	
	public SoloudResultType Init()
	{
		return (SoloudResultType) SoloudInterop.Soloud_init(Handle);
	}
	
	public SoloudResultType InitEx(SoloudFlag flags, SoloudBackendType backend, uint samplerate, uint bufferSize, uint channels)
	{
		return (SoloudResultType) SoloudInterop.Soloud_initEx(Handle, (uint) flags, (uint) backend, samplerate, bufferSize, channels);
	}
	
	public void Deinit()
	{
		SoloudInterop.Soloud_deinit(Handle);
	}
	
	public SoloudResultType Pause()
	{
		return (SoloudResultType) SoloudInterop.Soloud_pause(Handle);
	}
	
	public SoloudResultType Resume()
	{
		return (SoloudResultType) SoloudInterop.Soloud_resume(Handle);
	}
	
	public uint GetVersion()
	{
		return SoloudInterop.Soloud_getVersion(Handle);
	}
	
	public string GetErrorString(SoloudResultType errorCode)
	{
		sbyte* error = SoloudInterop.Soloud_getErrorString(Handle, (int) errorCode);
		return Marshal.PtrToStringAnsi((IntPtr) error) ?? string.Empty;
	}
	
	public SoloudBackendType GetBackendType()
	{
		return (SoloudBackendType) SoloudInterop.Soloud_getBackendId(Handle);
	}
	
	public string GetBackendString()
	{
		sbyte* str = SoloudInterop.Soloud_getBackendString(Handle);
		return Marshal.PtrToStringAnsi((IntPtr) str) ?? string.Empty;
	}
	
	public uint GetBackendChannels()
	{
		return SoloudInterop.Soloud_getBackendChannels(Handle);
	}
	
	public uint GetBackendSamplerate()
	{
		return SoloudInterop.Soloud_getBackendSamplerate(Handle);
	}
	
	public uint GetBackendBufferSize()
	{
		return SoloudInterop.Soloud_getBackendBufferSize(Handle);
	}
	
	public SoloudResultType SetSpeakerPosition(uint channel, float x, float y, float z)
	{
		return (SoloudResultType) SoloudInterop.Soloud_setSpeakerPosition(Handle, channel, x, y, z);
	}
	
	public SoloudResultType GetSpeakerPosition(uint channel, out float x, out float y, out float z)
	{
		fixed (float* _x = &x, _y = &y, _z = &z)
		{
			SoloudResultType result = (SoloudResultType) SoloudInterop.Soloud_getSpeakerPosition(Handle, channel, _x, _y, _z);
			x = *_x;
			y = *_y;
			z = *_z;
			return result;
		}
	}
	
	public SoloudResultType GetSpeakerPosition(uint channel, out Vector3 position)
	{
		float x, y, z;
		SoloudResultType result = GetSpeakerPosition(channel, out x, out y, out z);
		position = new Vector3(x, y, z);
		return result;
	}
	
	public VoiceHandle Play(Wav sound, float volume = -1.0f, float pan = 0.0f, bool paused = false, uint bus = 0)
	{
		uint handle = SoloudInterop.Soloud_playEx(Handle, sound.Handle, volume, pan, paused ? 1 : 0, bus);
		return new VoiceHandle(this, handle);
	}
	
	public VoiceHandle PlayClocked(double soundTime, Wav sound, float volume = -1.0f, float pan = 0.0f, uint bus = 0)
	{
		uint handle = SoloudInterop.Soloud_playClockedEx(Handle, soundTime, sound.Handle, volume, pan, bus);
		return new VoiceHandle(this, handle);
	}
	
	public VoiceHandle Play3D(Wav sound, float posX, float posY, float posZ, float velX = 0.0f, float velY = 0.0f, float velZ = 0.0f, float volume = 1.0f, bool paused = false, uint bus = 0)
	{
		uint handle = SoloudInterop.Soloud_play3dEx(Handle, sound.Handle, posX, posY, posZ, velX, velY, velZ, volume, paused ? 1 : 0, bus);
		return new VoiceHandle(this, handle);
	}
	
	public VoiceHandle Play3DClocked(double soundTime, Wav sound, float posX, float posY, float posZ, float velX = 0.0f, float velY = 0.0f, float velZ = 0.0f, float volume = 1.0f, uint bus = 0)
	{
		uint handle = SoloudInterop.Soloud_play3dClockedEx(Handle, soundTime, sound.Handle, posX, posY, posZ, velX, velY, velZ, volume, bus);
		return new VoiceHandle(this, handle);
	}
	
	public VoiceHandle PlayBackground(Wav sound, float volume = -1.0f, bool paused = false, uint bus = 0)
	{
		uint handle = SoloudInterop.Soloud_playBackgroundEx(Handle, sound.Handle, volume, paused ? 1 : 0, bus);
		return new VoiceHandle(this, handle);
	}
	
	public SoloudResultType Seek(VoiceHandle voice, double seconds)
	{
		return (SoloudResultType) SoloudInterop.Soloud_seek(Handle, voice.Handle, seconds);
	}
	
	public void Stop(VoiceHandle voice)
	{
		SoloudInterop.Soloud_stop(Handle, voice.Handle);
	}
	
	public void StopAll()
	{
		SoloudInterop.Soloud_stopAll(Handle);
	}
	
	public void StopAudioSource(Wav sound)
	{
		SoloudInterop.Soloud_stopAudioSource(Handle, sound.Handle);
	}
	
	public int CountAudioSource(Wav sound)
	{
		return SoloudInterop.Soloud_countAudioSource(Handle, sound.Handle);
	}
	
	public void SetFilterParameter()
	{
		throw new NotImplementedException();
	}
	
	public float GetFilterParameter()
	{
		throw new NotImplementedException();
	}
	
	public void FadeFilterParameter()
	{
		throw new NotImplementedException();
	}
	
	public void OscillateFilterParameter()
	{
		throw new NotImplementedException();
	}
	
	public double GetStreamTime(VoiceHandle voice)
	{
		return SoloudInterop.Soloud_getStreamTime(Handle, voice.Handle);
	}
	
	public double GetStreamPosition(VoiceHandle voice)
	{
		return SoloudInterop.Soloud_getStreamPosition(Handle, voice.Handle);
	}
	
	public bool GetPause(VoiceHandle voice)
	{
		return SoloudInterop.Soloud_getPause(Handle, voice.Handle) > 0;
	}
	
	public float GetVolume(VoiceHandle voice)
	{
		return SoloudInterop.Soloud_getVolume(Handle, voice.Handle);
	}
	
	public float GetOverallVolume(VoiceHandle voice)
	{
		return SoloudInterop.Soloud_getOverallVolume(Handle, voice.Handle);
	}
	
	public float GetPan(VoiceHandle voice)
	{
		return SoloudInterop.Soloud_getPan(Handle, voice.Handle);
	}
	
	public float GetSamplerate(VoiceHandle voice)
	{
		return SoloudInterop.Soloud_getSamplerate(Handle, voice.Handle);
	}
	
	// TODO: unsure if this is a bool
	public int GetProtectVoice(VoiceHandle voice)
	{
		return SoloudInterop.Soloud_getProtectVoice(Handle, voice.Handle);
	}
	
	public uint GetActiveVoiceCount()
	{
		return SoloudInterop.Soloud_getActiveVoiceCount(Handle);
	}
	
	public uint GetVoiceCount()
	{
		return SoloudInterop.Soloud_getVoiceCount(Handle);
	}
	
	public bool IsValidVoiceHandle(VoiceHandle voice)
	{
		return SoloudInterop.Soloud_isValidVoiceHandle(Handle, voice.Handle) > 0;
	}
	
	public float GetRelativePlaySpeed(VoiceHandle voice)
	{
		return SoloudInterop.Soloud_getRelativePlaySpeed(Handle, voice.Handle);
	}
	
	public float GetPostClipScaler()
	{
		return SoloudInterop.Soloud_getPostClipScaler(Handle);

	}
	
	// TODO: unsure of the return type
	public uint GetMainResampler()
	{
		return SoloudInterop.Soloud_getMainResampler(Handle);
	}
	
	public float GetGlobalVolume()
	{
		return SoloudInterop.Soloud_getGlobalVolume(Handle);
	}
	
	public uint GetMaxActiveVoiceCount()
	{
		return SoloudInterop.Soloud_getMaxActiveVoiceCount(Handle);
	}
	
	public bool GetLooping(VoiceHandle voice)
	{
		return SoloudInterop.Soloud_getLooping(Handle, voice.Handle) > 0;
	}
	
	public bool GetAutoStop(VoiceHandle voice)
	{
		return SoloudInterop.Soloud_getAutoStop(Handle, voice.Handle) > 0;
	}
	
	public double GetLoopPoint(VoiceHandle voice)
	{
		return SoloudInterop.Soloud_getLoopPoint(Handle, voice.Handle);
	}
	
	public void SetLoopPoint(VoiceHandle voice, double loopPoint)
	{
		SoloudInterop.Soloud_setLoopPoint(Handle, voice.Handle, loopPoint);
	}
	
	public void SetLooping(VoiceHandle voice, bool looping)
	{
		SoloudInterop.Soloud_setLooping(Handle, voice.Handle, looping ? 1 : 0);
	}
	
	public void SetAutoStop(VoiceHandle voice, bool autoStop)
	{
		SoloudInterop.Soloud_setAutoStop(Handle, voice.Handle, autoStop ? 1 : 0);
	}
	
	public SoloudResultType SetMaxActiveVoiceCount(uint voiceCount)
	{
		return (SoloudResultType) SoloudInterop.Soloud_setMaxActiveVoiceCount(Handle, voiceCount);
	}
	
	public void SetInaudibleBehavior(VoiceHandle voice, bool mustTick, bool kill)
	{
		SoloudInterop.Soloud_setInaudibleBehavior(Handle, voice.Handle, mustTick ? 1 : 0, kill ? 1 : 0);
	}
	
	public void SetGlobalVolume(float volume)
	{
		SoloudInterop.Soloud_setGlobalVolume(Handle, volume);
	}
	
	public void SetPostClipScaler(float scaler)
	{
		SoloudInterop.Soloud_setPostClipScaler(Handle, scaler);
	}
	
	// TODO: unknown type resampler
	public void SetMainResampler(uint resampler)
	{
		SoloudInterop.Soloud_setMainResampler(Handle, resampler);
	}
	
	public void SetPause(VoiceHandle voice, bool pause)
	{
		SoloudInterop.Soloud_setPause(Handle, voice.Handle, pause ? 1 : 0);
	}
	
	public void SetPauseAll(bool pause)
	{
		SoloudInterop.Soloud_setPauseAll(Handle, pause ? 1 : 0);
	}
	
	public SoloudResultType SetRelativePlaySpeed(VoiceHandle voice, float speed)
	{
		return (SoloudResultType) SoloudInterop.Soloud_setRelativePlaySpeed(Handle, voice.Handle, speed);
	}
	
	public void SetProtectVoice(VoiceHandle voice, bool protect)
	{
		SoloudInterop.Soloud_setProtectVoice(Handle, voice.Handle, protect ? 1 : 0);
	}
	
	public void SetSamplerate(VoiceHandle voice, float samplerate)
	{
		SoloudInterop.Soloud_setSamplerate(Handle, voice.Handle, samplerate);
	}
	
	public void SetPan(VoiceHandle voice, float pan)
	{
		SoloudInterop.Soloud_setPan(Handle, voice.Handle, pan);
	}
	
	public void SetPanAbsolute(VoiceHandle voice, float lVolume, float rVolume)
	{
		SoloudInterop.Soloud_setPanAbsolute(Handle, voice.Handle, lVolume, rVolume);
	}
	
	public void SetChannelVolume(VoiceHandle voice, uint channel, float volume)
	{
		SoloudInterop.Soloud_setChannelVolume(Handle, voice.Handle, channel, volume);
	}
	
	public void SetVolume(VoiceHandle voice, float volume)
	{
		SoloudInterop.Soloud_setVolume(Handle, voice.Handle, volume);
	}
	
	// TODO: unknown type samples
	public void SetDelaySamples(VoiceHandle voice, uint samples)
	{
		SoloudInterop.Soloud_setDelaySamples(Handle, voice.Handle, samples);
	}
	
	public void FadeVolume(VoiceHandle voice, float to, double time)
	{
		SoloudInterop.Soloud_fadeVolume(Handle, voice.Handle, to, time);
	}
	
	public void FadePan(VoiceHandle voice, float to, double time)
	{
		SoloudInterop.Soloud_fadePan(Handle, voice.Handle, to, time);
	}
	
	public void FadeRelativePlaySpeed(VoiceHandle voice, float to, double time)
	{
		SoloudInterop.Soloud_fadeRelativePlaySpeed(Handle, voice.Handle, to, time);
	}
	
	public void FadeGlobalVolume(float to, double time)
	{
		SoloudInterop.Soloud_fadeGlobalVolume(Handle, to, time);
	}
	
	public void SchedulePause(VoiceHandle voice, double time)
	{
		SoloudInterop.Soloud_schedulePause(Handle, voice.Handle, time);
	}
	
	public void ScheduleStop(VoiceHandle voice, double time)
	{
		SoloudInterop.Soloud_scheduleStop(Handle, voice.Handle, time);
	}
	
	public void OscillateVolume(VoiceHandle voice, float from, float to, double time)
	{
		SoloudInterop.Soloud_oscillateVolume(Handle, voice.Handle, from, to, time);
	}
	
	public void OscillatePan(VoiceHandle voice, float from, float to, double time)
	{
		SoloudInterop.Soloud_oscillatePan(Handle, voice.Handle, from, to, time);
	}
	
	public void OscillateRelativePlaySpeed(VoiceHandle voice, float from, float to, double time)
	{
		SoloudInterop.Soloud_oscillateRelativePlaySpeed(Handle, voice.Handle, from, to, time);
	}
	
	public void OscillateGlobalVolume(float from, float to, double time)
	{
		SoloudInterop.Soloud_oscillateGlobalVolume(Handle, from, to, time);
	}
	
	public void SetGlobalFilter()
	{
		throw new NotImplementedException();
	}
	
	public void SetVisualizationEnable(bool enable)
	{
		SoloudInterop.Soloud_setVisualizationEnable(Handle, enable ? 1 : 0);
	}
	
	public float* CalcFFT()
	{
		throw new NotImplementedException();
	}
	
	public float* GetWave()
	{
		throw new NotImplementedException();
	}
	
	// TODO: unknown type channel
	public float GetApproximateVolume(uint channel)
	{
		return SoloudInterop.Soloud_getApproximateVolume(Handle, channel);
	}
	
	public uint GetLoopCount(VoiceHandle voice)
	{
		return SoloudInterop.Soloud_getLoopCount(Handle, voice.Handle);
	}
	
	public float GetInfo(VoiceHandle voice, uint infoKey)
	{
		throw new NotImplementedException();
	}
	
	// TODO: not sure return type
	public uint CreateVoiceGroup()
	{
		throw new NotImplementedException();
	}
	
	// TODO: not sure return type
	public int DestroyVoiceGroup()
	{
		throw new NotImplementedException();
	}
	
	// TODO: not sure return type
	public int AddVoiceToGroup()
	{
		throw new NotImplementedException();
	}
	
	public int IsVoiceGrouo()
	{
		throw new NotImplementedException();
	}
	
	public int IsVoiceGroupEmpty()
	{
		throw new NotImplementedException();
	}
	
	public void Update3DAudio()
	{
		SoloudInterop.Soloud_update3dAudio(Handle);
	}
	
	public SoloudResultType Set3DSoundSpeed(float speed)
	{
		return (SoloudResultType) SoloudInterop.Soloud_set3dSoundSpeed(Handle, speed);
	}
	
	public float Get3DSoundSpeed()
	{
		return SoloudInterop.Soloud_get3dSoundSpeed(Handle);
	}
	
	public void Set3DListenerParameters(float posX, float posY, float posZ, float atX, float atY, float atZ, float upX, float upY, float upZ, float velX = 0.0f, float velY = 0.0f, float velZ = 0.0f)
	{
		SoloudInterop.Soloud_set3dListenerParametersEx(Handle, posX, posY, posZ, atX, atY, atZ, upX, upY, upZ, velX, velY, velZ);
	}
	
	public void Set3DListenerPosition(float posX, float posY, float posZ)
	{
		SoloudInterop.Soloud_set3dListenerPosition(Handle, posX, posY, posZ);
	}
	
	public void Set3DListenerAt(float atX, float atY, float atZ)
	{
		SoloudInterop.Soloud_set3dListenerAt(Handle, atX, atY, atZ);
	}
	
	public void Set3DListenerUp(float upX, float upY, float upZ)
	{
		SoloudInterop.Soloud_set3dListenerUp(Handle, upX, upY, upZ);
	}
	
	public void Set3DListenerVelocity(float velX, float velY, float velZ)
	{
		SoloudInterop.Soloud_set3dListenerVelocity(Handle, velX, velY, velZ);
	}
	
	public void Set3DSourceParameters(VoiceHandle voice, float posX, float posY, float posZ, float velX = 0.0f, float velY = 0.0f, float velZ = 0.0f)
	{
		SoloudInterop.Soloud_set3dSourceParametersEx(Handle, voice.Handle, posX, posY, posZ, velX, velY, velZ);
	}
	
	public void Set3DSourcePosition(VoiceHandle voice, float posX, float posY, float posZ)
	{
		SoloudInterop.Soloud_set3dSourcePosition(Handle, voice.Handle, posX, posY, posZ);
	}
	
	public void Set3dSourceVelocity(VoiceHandle voice, float velX, float velY, float velZ)
	{
		SoloudInterop.Soloud_set3dSourceVelocity(Handle, voice.Handle, velX, velY, velZ);
	}
	
	public void Set3DSourceMinMaxDistance(VoiceHandle voice, float minDist, float maxDist)
	{
		SoloudInterop.Soloud_set3dSourceMinMaxDistance(Handle, voice.Handle, minDist, maxDist);
	}
	
	public void Set3DSourceAttenuation(VoiceHandle voice, AttenuationModelType attenuationModel, float rolloffFactor)
	{
		SoloudInterop.Soloud_set3dSourceAttenuation(Handle, voice.Handle, (uint) attenuationModel, rolloffFactor);
	}
	
	public void Set3DSourceDopplerFactor(VoiceHandle voice, float dopplerFactor)
	{
		SoloudInterop.Soloud_set3dSourceDopplerFactor(Handle, voice.Handle, dopplerFactor);
	}
	
	public void Mix()
	{
		throw new NotImplementedException();
	}
	
	public void MixSigned16()
	{
		throw new NotImplementedException();
	}
}

public sealed unsafe class Ay : IDisposable
{
	private bool _disposed;
	
	public bool IsDisposed => _disposed;
	
	private SafeAyContext _handle;
	internal SafeAyContext Handle
	{
		get
		{
			ThrowIfDisposed();
			return _handle;
		}
	}
	
	public Ay()
	{
		RefAy* ctx = SoloudInterop.Ay_create();
		_handle = new SafeAyContext((IntPtr) ctx);
	}
	
	public void Dispose()
	{
		Handle.Dispose();
		_disposed = true;
	}
	
	public void ThrowIfDisposed()
	{
		if (_disposed || _handle.IsInvalid)
			throw new ObjectDisposedException(GetType().FullName, "Attempt to use Ay when it's cleaned up.");
	}
	
	public void SetVolume(float volume)
	{
		SoloudInterop.Ay_setVolume(Handle, volume);
	}
	
	public void SetLooping(bool loop)
	{
		SoloudInterop.Ay_setLooping(Handle, loop ? 1 : 0);
	}
	
	public void SetAutoStop(bool autoStop)
	{
		SoloudInterop.Ay_setAutoStop(Handle, autoStop ? 1 : 0);
	}
	
	public void Set3DMinMaxDistance(float minDist, float maxDist)
	{
		SoloudInterop.Ay_set3dMinMaxDistance(Handle, minDist, maxDist);
	}
	
	public void Set3DAttenuation(AttenuationModelType attenuationModel, float rolloffFactor)
	{
		SoloudInterop.Ay_set3dAttenuation(Handle, (uint) attenuationModel, rolloffFactor);
	}
	
	public void Set3DDopplerFactor(float dopplerFactor)
	{
		SoloudInterop.Ay_set3dDopplerFactor(Handle, dopplerFactor);
	}
	
	public void Set3DListenerRelative()
	{
		throw new NotImplementedException();
	}
	
	public void Set3DDistanceDelay(int distanceDelay)
	{
		SoloudInterop.Ay_set3dDistanceDelay(Handle, distanceDelay);
	}
	
	public void Set3DCollider()
	{
		throw new NotImplementedException();
	}
	
	public void Set3DAttenuator()
	{
		throw new NotImplementedException();
	}
	
	public void SetInaudibleBehavior(bool mustTick, bool kill)
	{
		SoloudInterop.Ay_setInaudibleBehavior(Handle, mustTick ? 1 : 0, kill ? 1 : 0);
	}
	
	public void SetLoopPoint(double loopPoint)
	{
		SoloudInterop.Ay_setLoopPoint(Handle, loopPoint);
	}
	
	public double GetLoopPoint()
	{
		return SoloudInterop.Ay_getLoopPoint(Handle);
	}
	
	public void SetFilter()
	{
		throw new NotImplementedException();
	}
	
	public void Stop()
	{
		SoloudInterop.Ay_stop(Handle);
	}
}

public class Filter
{
	
}

public class AudioCollider
{
	
}

public class AudioAttenuator
{
	
}

public class Queue
{
	
}

public sealed unsafe class Wav : IDisposable
{
	private bool _disposed;
	
	public bool IsDisposed => _disposed;
	
	private SafeWavContext _handle;
	internal SafeWavContext Handle
	{
		get
		{
			ThrowIfDisposed();
			return _handle;
		}
	}
	
	public Wav()
	{
		RefWav* ctx = SoloudInterop.Wav_create();
		_handle = new SafeWavContext((IntPtr) ctx);
	}
	
	public void Dispose()
	{
		Handle.Dispose();
		_disposed = true;
	}
	
	public void ThrowIfDisposed()
	{
		if (_disposed || _handle.IsInvalid)
			throw new ObjectDisposedException(GetType().FullName, "Attempt to use Wav when it's cleaned up.");
	}
	
	public SoloudResultType Load(string filename)
	{
		// byte[] array = Encoding.ASCII.GetBytes(filename);
		// fixed (byte* _array = array)
		// {
		// 	return (SoloudResultType) SoloudInterop.Wav_load(Handle, (sbyte*) _array);
		// }
		return (SoloudResultType) SoloudInterop.Wav_load(Handle, filename);
	}
	
	public SoloudResultType LoadMem(byte* mem, uint length)
	{
		return (SoloudResultType) SoloudInterop.Wav_loadMemEx(Handle, mem, length, 1, 0);
	}
	
	public SoloudResultType LoadMem(byte* mem, int length) => LoadMem(mem, (uint) length);
	
	public SoloudResultType LoadMem(ReadOnlySpan<byte> mem)
	{
		fixed (byte* _mem = mem)
		{
			return LoadMem(_mem, mem.Length);
		}
	}
	
	public SoloudResultType LoadMarshaledMemory(IntPtr mem, uint length)
	{
		return (SoloudResultType) SoloudInterop.Wav_loadMemEx(Handle, (byte*) mem, length, 0, 0);
	}
	
	public SoloudResultType LoadMarshaledMemory(IntPtr mem, int length) => LoadMarshaledMemory(mem, (uint) length);
	
	public SoloudResultType LoadFile(SafeFileHandle handle)
	{
		throw new NotImplementedException();
	}
	
	public SoloudResultType LoadFile(FileStream stream)
	{
		throw new NotImplementedException();
	}
	
	// TODO: LoadRawWave*
	
	public double GetLength()
	{
		return SoloudInterop.Wav_getLength(Handle);
	}
	
	public void SetVolume(float volume)
	{
		SoloudInterop.Wav_setVolume(Handle, volume);
	}
	
	public void SetLooping(bool loop)
	{
		SoloudInterop.Wav_setLooping(Handle, loop ? 1 : 0);
	}
	
	public void SetAutoStop(bool autoStop)
	{
		SoloudInterop.Wav_setAutoStop(Handle, autoStop ? 1 : 0);
	}
	
	public void Set3DMinMaxDistance(float minDist, float maxDist)
	{
		SoloudInterop.Wav_set3dMinMaxDistance(Handle, minDist, maxDist);
	}
	
	public void Set3DAttenuation(AttenuationModelType type, float rolloffFactor)
	{
		SoloudInterop.Wav_set3dAttenuation(Handle, (uint) type, rolloffFactor);
	}
	
	public void Set3DDopplerFactor(float dopplerFactor)
	{
		SoloudInterop.Wav_set3dDopplerFactor(Handle, dopplerFactor);
	}
	
	public void Set3DListenerRelative(int listenerRelative)
	{
		SoloudInterop.Wav_set3dListenerRelative(Handle, listenerRelative);
	}
	
	public void Set3DListenerDelay(int distanceDelay)
	{
		SoloudInterop.Wav_set3dDistanceDelay(Handle, distanceDelay);
	}
	
	public void Set3DCollider()
	{
		throw new NotImplementedException();
	}
	
	public void Set3DAttenuator()
	{
		throw new NotImplementedException();
	}
	
	public void SetInaudibleBehavior()
	{
		throw new NotImplementedException();
	}
	
	public void SetLoopPoint(double loopPoint)
	{
		SoloudInterop.Wav_setLoopPoint(Handle, loopPoint);
	}
	
	public double GetLoopPoint()
	{
		return SoloudInterop.Wav_getLoopPoint(Handle);
	}
	
	public void SetFilter()
	{
		throw new NotImplementedException();
	}
	
	public void Stop()
	{
		SoloudInterop.Wav_stop(Handle);
	}
}

public sealed unsafe class WavStream : IDisposable
{
	private bool _disposed;
	
	public bool IsDisposed => _disposed;
	
	private SafeWavStreamContext _handle;
	internal SafeWavStreamContext Handle
	{
		get
		{
			ThrowIfDisposed();
			return _handle;
		}
		set
		{
			_handle = value;
		}
	}
	
	public WavStream()
	{
		RefWavStream* ctx = SoloudInterop.WavStream_create();
		_handle = new SafeWavStreamContext((IntPtr) ctx);
	}
	
	public void Dispose()
	{
		Handle.Dispose();
		_disposed = true;
	}
	
	public void ThrowIfDisposed()
	{
		if (_disposed || _handle.IsInvalid)
			throw new ObjectDisposedException(GetType().FullName, "Attempt to use WavStream when it's cleaned up.");
	}
	
	public void LoadFile()
	{
		throw new NotImplementedException();
	}
	
	public double GetLength()
	{
		return SoloudInterop.WavStream_getLength(Handle);
	}
	
	public void SetVolume(float volume)
	{
		SoloudInterop.WavStream_setVolume(Handle, volume);
	}
	
	public void SetLooping(bool loop)
	{
		SoloudInterop.WavStream_setLooping(Handle, loop ? 1 : 0);
	}
	
	public void SetAutoStop(bool autoStop)
	{
		SoloudInterop.WavStream_setAutoStop(Handle, autoStop ? 1 : 0);
	}
	
	public void Set3DMinMaxDistance(float minDist, float maxDist)
	{
		SoloudInterop.WavStream_set3dMinMaxDistance(Handle, minDist, maxDist);
	}
	
	public void Set3DAttenuation(AttenuationModelType type, float rolloffFactor)
	{
		SoloudInterop.WavStream_set3dAttenuation(Handle, (uint) type, rolloffFactor);
	}
	
	public void Set3DDopplerFactor(float dopplerFactor)
	{
		SoloudInterop.WavStream_set3dDopplerFactor(Handle, dopplerFactor);
	}
	
	public void Set3DDistanceDelay(int distanceDelay)
	{
		SoloudInterop.WavStream_set3dDistanceDelay(Handle, distanceDelay);
	}
	
	public void Set3DListenerRelative(int listenerRelative)
	{
		SoloudInterop.WavStream_set3dListenerRelative(Handle, listenerRelative);
	}
	
	public void Set3DCollider()
	{
		throw new NotImplementedException();
	}
	
	public void Set3DAttenuator()
	{
		throw new NotImplementedException();
	}
	
	public void SetInaudibleBehavior(bool mustTick, bool kill)
	{
		SoloudInterop.WavStream_setInaudibleBehavior(Handle, mustTick ? 1 : 0, kill ? 1 : 0);
	}
	
	public void SetLoopPoint(double loopPoint)
	{
		SoloudInterop.WavStream_setLoopPoint(Handle, loopPoint);
	}
	
	public double GetLoopPoint()
	{
		return SoloudInterop.WavStream_getLoopPoint(Handle);
	}
	
	public void SetFilter()
	{
		throw new NotImplementedException();
	}
	
	public void Stop()
	{
		SoloudInterop.WavStream_stop(Handle);
	}
}

public sealed unsafe class Bus : IDisposable
{
	private bool _disposed;
	
	public bool IsDisposed => _disposed;
	
	private SafeBusContext _handle;
	internal SafeBusContext Handle
	{
		get
		{
			ThrowIfDisposed();
			return _handle;
		}
		set
		{
			_handle = value;
		}
	}
	
	public Bus()
	{
		RefBus* ctx = SoloudInterop.Bus_create();
		_handle = new SafeBusContext((IntPtr) ctx);
	}
	
	public void Dispose()
	{
		Handle.Dispose();
		_disposed = true;
	}
	
	public void ThrowIfDisposed()
	{
		if (_disposed || _handle.IsInvalid)
			throw new ObjectDisposedException(GetType().FullName, "Attempt to use Bus when it's cleaned up.");
	}
	
	public void SetFilter()
	{
		throw new NotImplementedException();
	}
	
	public BusHandle Play(Wav voice, float volume = 1.0f, float pan = 0.0f, bool paused = false)
	{
		uint handle = SoloudInterop.Bus_playEx(Handle, voice.Handle, volume, pan, paused ? 1 : 0);
		return new BusHandle(this, handle);
	}
	
	public BusHandle PlayClocked(double soundTime, Wav sound, float volume = 1.0f, float pan = 0.0f)
	{
		uint handle = SoloudInterop.Bus_playClockedEx(Handle, soundTime, sound.Handle, volume, pan);
		return new BusHandle(this, handle);
	}
	
	public BusHandle Play3D(Wav sound, float posX, float posY, float posZ, float velX = 0.0f, float velY = 0.0f, float velZ = 0.0f, float volume = 1.0f, bool paused = false)
	{
		uint handle = SoloudInterop.Bus_play3dEx(Handle, sound.Handle, posX, posY, posZ, velX, velY, velZ, volume, paused ? 1 : 0);
		return new BusHandle(this, handle);
	}
	
	public BusHandle Play3DClocked(double soundTime, Wav sound, float posX, float posY, float posZ, float velX = 0.0f, float velY = 0.0f, float velZ = 0.0f, float volume = 1.0f)
	{
		uint handle = SoloudInterop.Bus_play3dClockedEx(Handle, soundTime, sound.Handle, posX, posY, posZ, velX, velY, velZ, volume);
		return new BusHandle(this, handle);
	}
	
	public SoloudResultType SetChannels(uint channels)
	{
		return (SoloudResultType) SoloudInterop.Bus_setChannels(Handle, channels);
	}
	
	public void SetVisualizationEnable(bool enable)
	{
		SoloudInterop.Bus_setVisualizationEnable(Handle, enable ? 1 : 0);
	}
	
	public void AnnexSound(VoiceHandle voice)
	{
		SoloudInterop.Bus_annexSound(Handle, voice.Handle);
	}
	
	// TODO: needs testing
	public float[] CalcFFT()
	{
		float* data = SoloudInterop.Bus_calcFFT(Handle);
		return new ReadOnlySpan<float>(data, 256).ToArray();
	}
	
	public float[] GetWave()
	{
		float* data = SoloudInterop.Bus_getWave(Handle);
		return new ReadOnlySpan<float>(data, 256).ToArray();
	}
	
	public float GetApproximateVolume(uint channel)
	{
		return SoloudInterop.Bus_getApproximateVolume(Handle, channel);
	}
	
	public uint GetActiveVoiceCount()
	{
		return SoloudInterop.Bus_getActiveVoiceCount(Handle);
	}
	
	public void GetResampler()
	{
		throw new NotImplementedException();
	}
	
	public void SetVolume(float volume)
	{
		SoloudInterop.Bus_setVolume(Handle, volume);
	}
	
	public void SetLooping(bool loop)
	{
		SoloudInterop.Bus_setLooping(Handle, loop ? 1 : 0);
	}
	
	public void SetAutoStop(bool autoStop)
	{
		SoloudInterop.Bus_setAutoStop(Handle, autoStop ? 1 : 0);
	}
	
	public void Set3DMinMaxDistance(float minDist, float maxDist)
	{
		SoloudInterop.Bus_set3dMinMaxDistance(Handle, minDist, maxDist);
	}
	
	public void Set3DAttenuation(AttenuationModelType attenuationModel, float attenuationRolloffFactor)
	{
		SoloudInterop.Bus_set3dAttenuation(Handle, (uint) attenuationModel, attenuationRolloffFactor);
	}
	
	public void Set3DDopplerFactor(float dopplerFactor)
	{
		SoloudInterop.Bus_set3dDopplerFactor(Handle, dopplerFactor);
	}
	
	public void Set3DListenerRelative(int listenerRelative)
	{
		SoloudInterop.Bus_set3dListenerRelative(Handle, listenerRelative);
	}
	
	public void Set3DDistanceDelay(int distanceDelay)
	{
		SoloudInterop.Bus_set3dDistanceDelay(Handle, distanceDelay);
	}
	
	public void Set3DCollider()
	{
		throw new NotImplementedException();
	}
	
	public void Set3DAttenuator()
	{
		throw new NotImplementedException();
	}
	
	public void SetInaudibleBehavior(bool mustTick, bool kill)
	{
		SoloudInterop.Bus_setInaudibleBehavior(Handle, mustTick ? 1 : 0, kill ? 1 : 0);
	}
	
	public void SetLoopPoint(double loopPoint)
	{
		SoloudInterop.Bus_setLoopPoint(Handle, loopPoint);
	}
	
	public double GetLoopPoint()
	{
		return SoloudInterop.Bus_getLoopPoint(Handle);
	}
	
	public void Stop()
	{
		SoloudInterop.Bus_stop(Handle);
	}
}
