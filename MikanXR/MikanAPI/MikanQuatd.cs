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

public class MikanQuatd : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal MikanQuatd(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(MikanQuatd obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(MikanQuatd obj) {
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

  ~MikanQuatd() {
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
          MikanClientPINVOKE.delete_MikanQuatd(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public double w {
    set {
      MikanClientPINVOKE.MikanQuatd_w_set(swigCPtr, value);
    } 
    get {
      double ret = MikanClientPINVOKE.MikanQuatd_w_get(swigCPtr);
      return ret;
    } 
  }

  public double x {
    set {
      MikanClientPINVOKE.MikanQuatd_x_set(swigCPtr, value);
    } 
    get {
      double ret = MikanClientPINVOKE.MikanQuatd_x_get(swigCPtr);
      return ret;
    } 
  }

  public double y {
    set {
      MikanClientPINVOKE.MikanQuatd_y_set(swigCPtr, value);
    } 
    get {
      double ret = MikanClientPINVOKE.MikanQuatd_y_get(swigCPtr);
      return ret;
    } 
  }

  public double z {
    set {
      MikanClientPINVOKE.MikanQuatd_z_set(swigCPtr, value);
    } 
    get {
      double ret = MikanClientPINVOKE.MikanQuatd_z_get(swigCPtr);
      return ret;
    } 
  }

  public MikanQuatd() : this(MikanClientPINVOKE.new_MikanQuatd(), true) {
  }

}

}
