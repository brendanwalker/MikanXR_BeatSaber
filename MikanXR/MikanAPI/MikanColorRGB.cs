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

public class MikanColorRGB : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal MikanColorRGB(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(MikanColorRGB obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(MikanColorRGB obj) {
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

  ~MikanColorRGB() {
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
          MikanClientPINVOKE.delete_MikanColorRGB(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public float r {
    set {
      MikanClientPINVOKE.MikanColorRGB_r_set(swigCPtr, value);
    } 
    get {
      float ret = MikanClientPINVOKE.MikanColorRGB_r_get(swigCPtr);
      return ret;
    } 
  }

  public float g {
    set {
      MikanClientPINVOKE.MikanColorRGB_g_set(swigCPtr, value);
    } 
    get {
      float ret = MikanClientPINVOKE.MikanColorRGB_g_get(swigCPtr);
      return ret;
    } 
  }

  public float b {
    set {
      MikanClientPINVOKE.MikanColorRGB_b_set(swigCPtr, value);
    } 
    get {
      float ret = MikanClientPINVOKE.MikanColorRGB_b_get(swigCPtr);
      return ret;
    } 
  }

  public MikanColorRGB() : this(MikanClientPINVOKE.new_MikanColorRGB(), true) {
  }

}

}
