using GraphicsConfigurator.Core.URP;
using UnityEngine.Rendering.Universal;

namespace GraphicsConfigurator.API.URP
{
    public static class Configuring
    {
        /// <summary>
        /// Managing the active pipeline asset
        /// </summary>
        public static URPAssetConfiguring CurrentURPA
        {
            get
            {
                m_URPAConfiguring.targetAsset = UniversalRenderPipeline.asset;
                return m_URPAConfiguring;
            }
            
        }
        private static readonly URPAssetConfiguring m_URPAConfiguring = new URPAssetConfiguring(UniversalRenderPipeline.asset);

    }
}
