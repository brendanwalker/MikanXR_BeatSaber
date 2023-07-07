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

public class MikanStereoIntrinsics : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal MikanStereoIntrinsics(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(MikanStereoIntrinsics obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(MikanStereoIntrinsics obj) {
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

  ~MikanStereoIntrinsics() {
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
          MikanClientPINVOKE.delete_MikanStereoIntrinsics(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public double pixel_width {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_pixel_width_set(swigCPtr, value);
    } 
    get {
      double ret = MikanClientPINVOKE.MikanStereoIntrinsics_pixel_width_get(swigCPtr);
      return ret;
    } 
  }

  public double pixel_height {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_pixel_height_set(swigCPtr, value);
    } 
    get {
      double ret = MikanClientPINVOKE.MikanStereoIntrinsics_pixel_height_get(swigCPtr);
      return ret;
    } 
  }

  public double hfov {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_hfov_set(swigCPtr, value);
    } 
    get {
      double ret = MikanClientPINVOKE.MikanStereoIntrinsics_hfov_get(swigCPtr);
      return ret;
    } 
  }

  public double vfov {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_vfov_set(swigCPtr, value);
    } 
    get {
      double ret = MikanClientPINVOKE.MikanStereoIntrinsics_vfov_get(swigCPtr);
      return ret;
    } 
  }

  public double znear {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_znear_set(swigCPtr, value);
    } 
    get {
      double ret = MikanClientPINVOKE.MikanStereoIntrinsics_znear_get(swigCPtr);
      return ret;
    } 
  }

  public double zfar {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_zfar_set(swigCPtr, value);
    } 
    get {
      double ret = MikanClientPINVOKE.MikanStereoIntrinsics_zfar_get(swigCPtr);
      return ret;
    } 
  }

  public MikanDistortionCoefficients left_distortion_coefficients {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_left_distortion_coefficients_set(swigCPtr, MikanDistortionCoefficients.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = MikanClientPINVOKE.MikanStereoIntrinsics_left_distortion_coefficients_get(swigCPtr);
      MikanDistortionCoefficients ret = (cPtr == global::System.IntPtr.Zero) ? null : new MikanDistortionCoefficients(cPtr, false);
      return ret;
    } 
  }

  public MikanMatrix3d left_camera_matrix {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_left_camera_matrix_set(swigCPtr, MikanMatrix3d.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = MikanClientPINVOKE.MikanStereoIntrinsics_left_camera_matrix_get(swigCPtr);
      MikanMatrix3d ret = (cPtr == global::System.IntPtr.Zero) ? null : new MikanMatrix3d(cPtr, false);
      return ret;
    } 
  }

  public MikanDistortionCoefficients right_distortion_coefficients {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_right_distortion_coefficients_set(swigCPtr, MikanDistortionCoefficients.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = MikanClientPINVOKE.MikanStereoIntrinsics_right_distortion_coefficients_get(swigCPtr);
      MikanDistortionCoefficients ret = (cPtr == global::System.IntPtr.Zero) ? null : new MikanDistortionCoefficients(cPtr, false);
      return ret;
    } 
  }

  public MikanMatrix3d right_camera_matrix {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_right_camera_matrix_set(swigCPtr, MikanMatrix3d.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = MikanClientPINVOKE.MikanStereoIntrinsics_right_camera_matrix_get(swigCPtr);
      MikanMatrix3d ret = (cPtr == global::System.IntPtr.Zero) ? null : new MikanMatrix3d(cPtr, false);
      return ret;
    } 
  }

  public MikanMatrix3d left_rectification_rotation {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_left_rectification_rotation_set(swigCPtr, MikanMatrix3d.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = MikanClientPINVOKE.MikanStereoIntrinsics_left_rectification_rotation_get(swigCPtr);
      MikanMatrix3d ret = (cPtr == global::System.IntPtr.Zero) ? null : new MikanMatrix3d(cPtr, false);
      return ret;
    } 
  }

  public MikanMatrix3d right_rectification_rotation {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_right_rectification_rotation_set(swigCPtr, MikanMatrix3d.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = MikanClientPINVOKE.MikanStereoIntrinsics_right_rectification_rotation_get(swigCPtr);
      MikanMatrix3d ret = (cPtr == global::System.IntPtr.Zero) ? null : new MikanMatrix3d(cPtr, false);
      return ret;
    } 
  }

  public MikanMatrix4x3d left_rectification_projection {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_left_rectification_projection_set(swigCPtr, MikanMatrix4x3d.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = MikanClientPINVOKE.MikanStereoIntrinsics_left_rectification_projection_get(swigCPtr);
      MikanMatrix4x3d ret = (cPtr == global::System.IntPtr.Zero) ? null : new MikanMatrix4x3d(cPtr, false);
      return ret;
    } 
  }

  public MikanMatrix4x3d right_rectification_projection {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_right_rectification_projection_set(swigCPtr, MikanMatrix4x3d.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = MikanClientPINVOKE.MikanStereoIntrinsics_right_rectification_projection_get(swigCPtr);
      MikanMatrix4x3d ret = (cPtr == global::System.IntPtr.Zero) ? null : new MikanMatrix4x3d(cPtr, false);
      return ret;
    } 
  }

  public MikanMatrix3d rotation_between_cameras {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_rotation_between_cameras_set(swigCPtr, MikanMatrix3d.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = MikanClientPINVOKE.MikanStereoIntrinsics_rotation_between_cameras_get(swigCPtr);
      MikanMatrix3d ret = (cPtr == global::System.IntPtr.Zero) ? null : new MikanMatrix3d(cPtr, false);
      return ret;
    } 
  }

  public MikanVector3d translation_between_cameras {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_translation_between_cameras_set(swigCPtr, MikanVector3d.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = MikanClientPINVOKE.MikanStereoIntrinsics_translation_between_cameras_get(swigCPtr);
      MikanVector3d ret = (cPtr == global::System.IntPtr.Zero) ? null : new MikanVector3d(cPtr, false);
      return ret;
    } 
  }

  public MikanMatrix3d essential_matrix {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_essential_matrix_set(swigCPtr, MikanMatrix3d.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = MikanClientPINVOKE.MikanStereoIntrinsics_essential_matrix_get(swigCPtr);
      MikanMatrix3d ret = (cPtr == global::System.IntPtr.Zero) ? null : new MikanMatrix3d(cPtr, false);
      return ret;
    } 
  }

  public MikanMatrix3d fundamental_matrix {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_fundamental_matrix_set(swigCPtr, MikanMatrix3d.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = MikanClientPINVOKE.MikanStereoIntrinsics_fundamental_matrix_get(swigCPtr);
      MikanMatrix3d ret = (cPtr == global::System.IntPtr.Zero) ? null : new MikanMatrix3d(cPtr, false);
      return ret;
    } 
  }

  public MikanMatrix4d reprojection_matrix {
    set {
      MikanClientPINVOKE.MikanStereoIntrinsics_reprojection_matrix_set(swigCPtr, MikanMatrix4d.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = MikanClientPINVOKE.MikanStereoIntrinsics_reprojection_matrix_get(swigCPtr);
      MikanMatrix4d ret = (cPtr == global::System.IntPtr.Zero) ? null : new MikanMatrix4d(cPtr, false);
      return ret;
    } 
  }

  public MikanStereoIntrinsics() : this(MikanClientPINVOKE.new_MikanStereoIntrinsics(), true) {
  }

}

}
