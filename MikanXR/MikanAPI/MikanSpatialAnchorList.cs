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

public class MikanSpatialAnchorList : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal MikanSpatialAnchorList(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(MikanSpatialAnchorList obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(MikanSpatialAnchorList obj) {
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

  ~MikanSpatialAnchorList() {
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
          MikanClientPINVOKE.delete_MikanSpatialAnchorList(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public int[] spatial_anchor_id_list {
    get {
      System.IntPtr cPtr = MikanClientPINVOKE.MikanSpatialAnchorList_spatial_anchor_id_list_get(swigCPtr);
      int len = (int)spatial_anchor_count;
      if (len<=0)
      {
        return null;
      }
      int[] returnArray = new int[len];
      System.Runtime.InteropServices.Marshal.Copy(cPtr, returnArray, 0, len);
       
      return returnArray;
    }
  
  }

  public int spatial_anchor_count {
    get {
      int ret = MikanClientPINVOKE.MikanSpatialAnchorList_spatial_anchor_count_get(swigCPtr);
      return ret;
    } 
  }

  public MikanSpatialAnchorList() : this(MikanClientPINVOKE.new_MikanSpatialAnchorList(), true) {
  }

}

}
