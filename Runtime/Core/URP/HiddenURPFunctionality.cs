using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using ShadowResolution = UnityEngine.Rendering.Universal.ShadowResolution;

namespace GraphicsConfigurator.Core.URP
{
    internal static partial class URPFunctionality
    {
        
        #region FieldsInfo

        private static readonly Type pipelineAssetType = typeof(UniversalRenderPipelineAsset);
        private const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
        
        private static readonly FieldInfo m_OpaqueDownsampling = getFieldInfo("m_OpaqueDownsampling");
        private static readonly FieldInfo m_SupportsTerrainHoles = getFieldInfo("m_SupportsTerrainHoles");
        private static readonly FieldInfo m_MSAA = getFieldInfo("m_MSAA");
        private static readonly FieldInfo m_MainLightRenderingMode = getFieldInfo("m_MainLightRenderingMode");
        private static readonly FieldInfo m_MainLightShadowsSupported = getFieldInfo("m_MainLightShadowsSupported");
        private static readonly FieldInfo m_MainLightShadowmapResolution = getFieldInfo("m_MainLightShadowmapResolution");
        private static readonly FieldInfo m_AdditionalLightsRenderingMode = getFieldInfo("m_AdditionalLightsRenderingMode");
        private static readonly FieldInfo m_AdditionalLightShadowsSupported = getFieldInfo("m_AdditionalLightShadowsSupported");
        private static readonly FieldInfo m_AdditionalLightsShadowmapResolution = getFieldInfo("m_AdditionalLightsShadowmapResolution");
        private static readonly FieldInfo m_AdditionalLightsShadowResolutionTierLow = getFieldInfo("m_AdditionalLightsShadowResolutionTierLow");
        private static readonly FieldInfo m_AdditionalLightsShadowResolutionTierMedium = getFieldInfo("m_AdditionalLightsShadowResolutionTierMedium");
        private static readonly FieldInfo m_AdditionalLightsShadowResolutionTierHigh = getFieldInfo("m_AdditionalLightsShadowResolutionTierHigh");
        private static readonly FieldInfo m_Cascade2Split = getFieldInfo("m_Cascade2Split");
        private static readonly FieldInfo m_Cascade3Split = getFieldInfo("m_Cascade3Split");
        private static readonly FieldInfo m_Cascade4Split = getFieldInfo("m_Cascade4Split");
        private static readonly FieldInfo m_SoftShadowsSupported = getFieldInfo("m_SoftShadowsSupported");
        private static readonly FieldInfo m_UseFastSRGBLinearConversion = getFieldInfo("m_UseFastSRGBLinearConversion");
        private static readonly FieldInfo m_MixedLightingSupported = getFieldInfo("m_MixedLightingSupported");

        private static FieldInfo getFieldInfo(string name) => pipelineAssetType.GetField(name, flags);
        
        #endregion
        
        #region General

        internal static Downsampling opaqueDownsampling(UniversalRenderPipelineAsset asset, Downsampling downsampling,
            bool activateOpaqueTexture = false)
        {
            if (activateOpaqueTexture) asset.supportsCameraOpaqueTexture = true;
            
            m_OpaqueDownsampling.SetValue(asset, downsampling);
            return asset.opaqueDownsampling;
        }

        internal static bool supportsTerrainHoles(UniversalRenderPipelineAsset asset, bool state)
        {
            m_SupportsTerrainHoles.SetValue(asset, state);
            return asset.supportsTerrainHoles;
        }

        #endregion

        #region Quality

        internal static MsaaQuality msaaQuality(UniversalRenderPipelineAsset asset, MsaaQuality quality)
        {
            m_MSAA.SetValue(asset, quality);
            return (MsaaQuality)asset.msaaSampleCount;
        }

        #endregion

        #region Lighting

        internal static LightRenderingMode mainLightRenderingMode(UniversalRenderPipelineAsset asset,
            LightRenderingMode mode)
        {
            if (mode == LightRenderingMode.PerVertex)
                throw new Exception("Main light rendering mode can not be 'PerVertex'");
            
            m_MainLightRenderingMode.SetValue(asset, mode);
            return asset.mainLightRenderingMode;
        }
        
        internal static bool supportsMainLightShadows(UniversalRenderPipelineAsset asset, bool state)
        {
            m_MainLightShadowsSupported.SetValue(asset, state);
            return asset.supportsMainLightShadows;
        }

        internal static ShadowResolution mainLightShadowmapResolution(UniversalRenderPipelineAsset asset,
            ShadowResolution resolution)
        {
            m_MainLightShadowmapResolution.SetValue(asset, resolution);
            return (ShadowResolution)asset.mainLightShadowmapResolution;
        }
        
        internal static LightRenderingMode additionalLightsRenderingMode(UniversalRenderPipelineAsset asset,
            LightRenderingMode mode)
        {
            m_AdditionalLightsRenderingMode.SetValue(asset, mode);
            return asset.additionalLightsRenderingMode;
        }
        
        internal static bool supportsAdditionalLightShadows(UniversalRenderPipelineAsset asset, bool state)
        {
            m_AdditionalLightShadowsSupported.SetValue(asset, state);
            return asset.supportsAdditionalLightShadows;
        }
        
        internal static ShadowResolution additionalLightsShadowmapResolution(UniversalRenderPipelineAsset asset,
            ShadowResolution resolution)
        {
            m_AdditionalLightsShadowmapResolution.SetValue(asset, resolution);
            return (ShadowResolution)asset.additionalLightsShadowmapResolution;
        }

        internal static int additionalLightsShadowResolutionTierLow(UniversalRenderPipelineAsset asset, int resolution)
        {
            m_AdditionalLightsShadowResolutionTierLow.SetValue(asset, resolution);
            return asset.additionalLightsShadowResolutionTierLow;
        }
        
        internal static int additionalLightsShadowResolutionTierMedium(UniversalRenderPipelineAsset asset, int resolution)
        {
            m_AdditionalLightsShadowResolutionTierMedium.SetValue(asset, resolution);
            return asset.additionalLightsShadowResolutionTierMedium;
        }
        
        internal static int additionalLightsShadowResolutionTierHigh(UniversalRenderPipelineAsset asset, int resolution)
        {
            m_AdditionalLightsShadowResolutionTierHigh.SetValue(asset, resolution);
            return asset.additionalLightsShadowResolutionTierHigh;
        }

        #endregion

        #region Shadows

        internal static float cascade2Split(UniversalRenderPipelineAsset asset, float value)
        {
            m_Cascade2Split.SetValue(asset, value);
            return asset.cascade2Split;
        }
        
        internal static Vector2 cascade3Split(UniversalRenderPipelineAsset asset, Vector2 value)
        {
            m_Cascade3Split.SetValue(asset, value);
            return asset.cascade3Split;
        }
        
        internal static Vector3 cascade4Split(UniversalRenderPipelineAsset asset, Vector3 value)
        {
            m_Cascade4Split.SetValue(asset, value);
            return asset.cascade4Split;
        }

        internal static bool supportsSoftShadows(UniversalRenderPipelineAsset asset, bool state)
        {
            m_SoftShadowsSupported.SetValue(asset, state);
            return asset.supportsSoftShadows;
        }

        #endregion

        #region Post-processing

        internal static bool useFastSRGBLinearConversion(UniversalRenderPipelineAsset asset, bool state)
        {
            m_UseFastSRGBLinearConversion.SetValue(asset, state);
            return asset.useFastSRGBLinearConversion;
        }

        #endregion
        
        #region Advanced

        internal static bool supportsMixedLighting(UniversalRenderPipelineAsset asset, bool state)
        {
            m_MixedLightingSupported.SetValue(asset, state);
            return asset.supportsMixedLighting;
        }

        #endregion
        
    }
}
