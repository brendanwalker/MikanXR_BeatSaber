//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (https://www.swig.org).
// Version 4.1.1
//
// Do not make changes to this file unless you know what you are doing - modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace Mikan {

public class MikanVideoSourceIntrinsics_intrinsics : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal MikanVideoSourceIntrinsics_intrinsics(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(MikanVideoSourceIntrinsics_intrinsics obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(MikanVideoSourceIntrinsics_intrinsics obj) {
    if (obj != null) {
      if (!obj.swigCMemOwn)
        throw new global::System.ApplicationException("Cannot release ownership as memory is not owned");
      global::System.Runtime.InteropServices.HandleRef ptr = obj.swigCPtr;
      obj.swigCMemOwn = false;
      obj.Dispose();
      return ptr;
    } else {
      return new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
    }
  }

  ~MikanVideoSourceIntrinsics_intrinsics() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          MikanClientPINVOKE.delete_MikanVideoSourceIntrinsics_intrinsics(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public MikanMonoIntrinsics mono {
    set {
      MikanClientPINVOKE.MikanVideoSourceIntrinsics_intrinsics_mono_set(swigCPtr, MikanMonoIntrinsics.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = MikanClientPINVOKE.MikanVideoSourceIntrinsics_intrinsics_mono_get(swigCPtr);
      MikanMonoIntrinsics ret = (cPtr == global::System.IntPtr.Zero) ? null : new MikanMonoIntrinsics(cPtr, false);
      return ret;
    } 
  }

  public MikanStereoIntrinsics stereo {
    set {
      MikanClientPINVOKE.MikanVideoSourceIntrinsics_intrinsics_stereo_set(swigCPtr, MikanStereoIntrinsics.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = MikanClientPINVOKE.MikanVideoSourceIntrinsics_intrinsics_stereo_get(swigCPtr);
      MikanStereoIntrinsics ret = (cPtr == global::System.IntPtr.Zero) ? null : new MikanStereoIntrinsics(cPtr, false);
      return ret;
    } 
  }

  public MikanVideoSourceIntrinsics_intrinsics() : this(MikanClientPINVOKE.new_MikanVideoSourceIntrinsics_intrinsics(), true) {
  }

}

}
