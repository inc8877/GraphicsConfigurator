using UnityEngine;
using UnityEngine.Rendering.Universal;
using ShadowResolution = UnityEngine.Rendering.Universal.ShadowResolution;

namespace GraphicsConfigurator.Core.URP
{
    public class URPAssetConfiguring
    {
        
        #region Constructor

        public URPAssetConfiguring(UniversalRenderPipelineAsset asset)
        {
            targetAsset = asset;
        }
        public UniversalRenderPipelineAsset targetAsset;

        #endregion

        #region General

        public bool DepthTexture(bool state) => URPFunctionality.depthTextureActivity(targetAsset, state);
        
        public bool OpaqueTexture(bool state) => URPFunctionality.opaqueTextureActivity(targetAsset, state);

        public Downsampling OpaqueDownsampling(Downsampling downsampling) =>
            URPFunctionality.opaqueDownsampling(targetAsset, downsampling);

        public bool TerrainHoles(bool state) => URPFunctionality.supportsTerrainHoles(targetAsset, state);

        #endregion

        #region Quality

        public bool HDR(bool state) => URPFunctionality.hdrActivity(targetAsset, state);
        
        public MsaaQuality AntiAliasing(MsaaQuality quality) => URPFunctionality.msaaQuality(targetAsset, quality);

        public float RenderScale(float scale) => URPFunctionality.renderScale(targetAsset, scale);

        #endregion

        #region Lighting

        // Main directional light Settings
        public LightRenderingMode MainLightMode(LightRenderingMode mode) =>
            URPFunctionality.mainLightRenderingMode(targetAsset, mode);

        public bool MainLightShadowsCasting(bool state) =>
            URPFunctionality.supportsMainLightShadows(targetAsset, state);

        public ShadowResolution MainLightShadowResolution(ShadowResolution resolution) =>
            URPFunctionality.mainLightShadowmapResolution(targetAsset, resolution);
        
        // Additional lights settings
        public LightRenderingMode AdditionalLightsMode(LightRenderingMode mode) =>
            URPFunctionality.additionalLightsRenderingMode(targetAsset, mode);

        public int MaxAdditionalLightsCount(int count) => URPFunctionality.additionalLightsCount(targetAsset, count);

        public bool AdditionalLightsShadowsCasting(bool state) =>
            URPFunctionality.supportsAdditionalLightShadows(targetAsset, state);

        public ShadowResolution AddtionalLightShadowResolution(ShadowResolution resolution) =>
            URPFunctionality.additionalLightsShadowmapResolution(targetAsset, resolution);

        #endregion

        #region Shadows

        public float ShadowDistance(float distance) => URPFunctionality.shadowDistance(targetAsset, distance);

        public int CascadeCount(int count) => URPFunctionality.shadowCascadeCount(targetAsset, count);

        public float Cascade2Split(float value) => URPFunctionality.cascade2Split(targetAsset, value);
        
        public Vector2 Cascade3Split(Vector2 value) => URPFunctionality.cascade3Split(targetAsset, value);
        
        public Vector3 Cascade4Split(Vector3 value) => URPFunctionality.cascade4Split(targetAsset, value);

        public float DepthBias(float bias) => URPFunctionality.shadowDepthBias(targetAsset, bias);

        public float NormalBias(float bias) => URPFunctionality.shadowNormalBias(targetAsset, bias);
        
        public bool SoftShadows(bool state) => URPFunctionality.supportsSoftShadows(targetAsset, state);

        #endregion

        #region Advanced

        public bool SRPBatcher(bool state) => URPFunctionality.useSRPBatcher(targetAsset, state);
        
        public bool DynamicBatching(bool state) => URPFunctionality.supportsDynamicBatching(targetAsset, state);
        
        public bool MixedLighting(bool state) => URPFunctionality.supportsMixedLighting(targetAsset, state);

        #endregion

    }
}