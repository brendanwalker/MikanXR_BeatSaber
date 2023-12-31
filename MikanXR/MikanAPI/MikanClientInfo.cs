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

public class MikanClientInfo : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal MikanClientInfo(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(MikanClientInfo obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(MikanClientInfo obj) {
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

  ~MikanClientInfo() {
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
          MikanClientPINVOKE.delete_MikanClientInfo(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public ulong supportedFeatures {
    set {
      MikanClientPINVOKE.MikanClientInfo_supportedFeatures_set(swigCPtr, value);
    } 
    get {
      ulong ret = MikanClientPINVOKE.MikanClientInfo_supportedFeatures_get(swigCPtr);
      return ret;
    } 
  }

  public string engineName {
    set {
      MikanClientPINVOKE.MikanClientInfo_engineName_set(swigCPtr, value);
    } 
    get {
      string ret = MikanClientPINVOKE.MikanClientInfo_engineName_get(swigCPtr);
      return ret;
    } 
  }

  public string engineVersion {
    set {
      MikanClientPINVOKE.MikanClientInfo_engineVersion_set(swigCPtr, value);
    } 
    get {
      string ret = MikanClientPINVOKE.MikanClientInfo_engineVersion_get(swigCPtr);
      return ret;
    } 
  }

  public string applicationName {
    set {
      MikanClientPINVOKE.MikanClientInfo_applicationName_set(swigCPtr, value);
    } 
    get {
      string ret = MikanClientPINVOKE.MikanClientInfo_applicationName_get(swigCPtr);
      return ret;
    } 
  }

  public string applicationVersion {
    set {
      MikanClientPINVOKE.MikanClientInfo_applicationVersion_set(swigCPtr, value);
    } 
    get {
      string ret = MikanClientPINVOKE.MikanClientInfo_applicationVersion_get(swigCPtr);
      return ret;
    } 
  }

  public string xrDeviceName {
    set {
      MikanClientPINVOKE.MikanClientInfo_xrDeviceName_set(swigCPtr, value);
    } 
    get {
      string ret = MikanClientPINVOKE.MikanClientInfo_xrDeviceName_get(swigCPtr);
      return ret;
    } 
  }

  public string mikanSdkVersion {
    set {
      MikanClientPINVOKE.MikanClientInfo_mikanSdkVersion_set(swigCPtr, value);
    } 
    get {
      string ret = MikanClientPINVOKE.MikanClientInfo_mikanSdkVersion_get(swigCPtr);
      return ret;
    } 
  }

  public MikanClientGraphicsApi graphicsAPI {
    set {
      MikanClientPINVOKE.MikanClientInfo_graphicsAPI_set(swigCPtr, (int)value);
    } 
    get {
      MikanClientGraphicsApi ret = (MikanClientGraphicsApi)MikanClientPINVOKE.MikanClientInfo_graphicsAPI_get(swigCPtr);
      return ret;
    } 
  }

  public MikanClientInfo() : this(MikanClientPINVOKE.new_MikanClientInfo(), true) {
  }

}

}
