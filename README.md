# README
 
Matlab code for running the ARTCAM-SWIR990-TEC from Artray

## Documentation

- I've put the correct documentation in the [Documentation](/Documentation) folder.

## Notes on the Artray Samples

- The code samples that are on the website are pretty decent. I'd recommend using the **C#** ones. 
  - If you would really rather use C then look at [this documentation](/Documentation/ARTCCM-SDK-MANUAL-TNIR-V1300_EN.pdf)
- C# is one of the **.NET** languages, a bunch of languages Microsoft uses, for developing on Windows systems. 
- These samples use **WinForms** 
- To run the samples, you need to copy the appropriate dll from the [SDK](/SDK) folder in the repo.
- The problem we had yesterday with the samples was that going to *Settings(S) >> Analog settings(A) >> Exposure* in the code was calling into the dll to show the dialog.
- I recommend using the *Sample_CS.NET_FullControl* sample to solve this problem as it includes its own version that you can find in *Settings(S) >> User filter settings >> Exposure time*
- You can view the underlying code for this in `UpDownExposureTime_ValueChanged` in the `Form3.cs` file.

## How things are structured

- Artray ships the camera controller as a **DLL** and you can pick the correct one for your system from the [SDK](/SDK) folder or by downloading from the [Artray website](http://www.artray.us/download_sdk.html).
  - This DLL is the thing that actually talks to the camera. 
  - You can learn about the functions the DLL exposes in the base [SDK documentation](/Documentation/ARTCCM-SDK-FUNCTION-MANUAL_EN-V1300.pdf) and the [extended documentation](/Documentation/ARTCCM-SDK-FUNCTION-MANUAL-TNIR-V1300_EN.pdf) for TNIR.
  - This documentation is pretty thorough, albeit opaque.
- The DLL is then *wrapped* in the `CArtCamSDK.cs` [wrapper class](/Samples/ARTCCM-TNIR-lib_EN_ver.1.3.1.3b/C#/CArtCamSDK.cs). This is included in the other samples, for example [here](/Samples/ARTCCM-TNIR-sample_EN_ver.1.3.1.3c/Sample/x64/C#.NET/Sample_CS.NET_FullControl/CArtCamSDK.cs). 
  - This is the wrapper for using C#, the other languages have their own wrappers.
  - There is pretty much a one-to-one correspondance between the wrapper functions and the dll.
  - The wrapper defines an object that is passed around like a variable. The samples often call this `m_CArtCam` and you can call the member functions (in C#). For example, to set the exposure time you might write: `m_CArtCam.SetExposureTime((value_in_ms);`
- On top of that is the program I've knocked together. It's super simple and will do the basics of your spec

