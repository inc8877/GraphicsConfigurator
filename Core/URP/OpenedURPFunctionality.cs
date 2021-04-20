using UnityEngine.Rendering.Universal;

namespace GraphicsConfigurator.Core.URP
{
    internal static partial class URPFunctionality
    {
        
        #region General

        internal static bool depthTextureActivity(UniversalRenderPipelineAsset asset, bool state) =>
            asset.supportsCameraDepthTexture = state;

        internal static bool opaqueTextureActivity(UniversalRenderPipelineAsset asset, bool state) =>
            asset.supportsCameraOpaqueTexture = state;

        #endregion
        
        #region Quality

        internal static bool hdrActivity(UniversalRenderPipelineAsset asset, bool state) =>
            asset.supportsHDR = state;

        internal static float renderScale(UniversalRenderPipelineAsset asset, float scale) =>
            asset.renderScale = scale;

        #endregion
        
        #region Lighting

        internal static int additionalLightsCount(UniversalRenderPipelineAsset asset, int count) =>
            asset.maxAdditionalLightsCount = count;

        #endregion
        
        #region Shadows

        internal static float shadowDistance(UniversalRenderPipelineAsset asset, float distance) =>
            asset.shadowDistance = distance;

        internal static int shadowCascadeCount(UniversalRenderPipelineAsset asset, int count) =>
            asset.shadowCascadeCount = count;

        internal static float shadowDepthBias(UniversalRenderPipelineAsset asset, float bias) =>
            asset.shadowDepthBias = bias;
        
        internal static float shadowNormalBias(UniversalRenderPipelineAsset asset, float bias) =>
            asset.shadowNormalBias = bias;

        #endregion

        #region Post-processing

        internal static ColorGradingMode colorGradingMode(UniversalRenderPipelineAsset asset, ColorGradingMode mode) =>
            asset.colorGradingMode = mode;

        internal static int colorGradingLutSize(UniversalRenderPipelineAsset asset, int size) =>
            asset.colorGradingLutSize = size;

        #endregion
        
        #region Advanced

        internal static bool useSRPBatcher(UniversalRenderPipelineAsset asset, bool state) =>
            asset.useSRPBatcher = state;
        
        internal static bool supportsDynamicBatching(UniversalRenderPipelineAsset asset, bool state) =>
            asset.supportsDynamicBatching = state;

        internal static ShaderVariantLogLevel shaderVariantLogLevel(UniversalRenderPipelineAsset asset,
            ShaderVariantLogLevel logLevel) => asset.shaderVariantLogLevel = logLevel;

        #endregion

    }
}