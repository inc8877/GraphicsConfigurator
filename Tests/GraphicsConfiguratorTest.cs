using System.Collections;
using GraphicsConfigurator.API.URP;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.TestTools;
using ShadowResolution = UnityEngine.Rendering.Universal.ShadowResolution;

namespace GraphicsConfigurator.Tests
{
    public class GraphicsConfiguratorTest
    {
        [UnityTest]
        public IEnumerator ForwardPass()
        {
            Configuring.CurrentURPA.TerrainHoles(true);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.HDR(true);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.AntiAliasing(MsaaQuality._2x);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.MainLightMode(LightRenderingMode.PerPixel);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.MainLightShadowsCasting(true);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.MainLightShadowResolution(ShadowResolution._2048);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.AdditionalLightsMode(LightRenderingMode.PerPixel);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.MaxAdditionalLightsCount(4);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.AdditionalLightsShadowsCasting(true);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.AddtionalLightShadowResolution(ShadowResolution._2048);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.ShadowDistance(100);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.CascadeCount(4);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.Cascade4Split(new Vector3(.1f, .3f, .7f));
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.DepthBias(1f);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.NormalBias(1f);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.SoftShadows(true);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.SRPBatcher(true);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.DynamicBatching(true);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.MixedLighting(true);
            yield return new WaitForSeconds(0.5f);
        }
    
        [UnityTest]
        public IEnumerator BackwardPass()
        {
            Configuring.CurrentURPA.TerrainHoles(false);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.HDR(false);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.AntiAliasing(MsaaQuality.Disabled);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.MainLightMode(LightRenderingMode.Disabled);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.MainLightShadowsCasting(false);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.MainLightShadowResolution(ShadowResolution._256);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.AdditionalLightsMode(LightRenderingMode.Disabled);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.MaxAdditionalLightsCount(0);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.AdditionalLightsShadowsCasting(false);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.AddtionalLightShadowResolution(ShadowResolution._256);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.ShadowDistance(0);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.CascadeCount(1);
            yield return new WaitForSeconds(0.5f);

            Configuring.CurrentURPA.DepthBias(0f);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.NormalBias(0f);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.SoftShadows(false);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.SRPBatcher(false);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.DynamicBatching(false);
            yield return new WaitForSeconds(0.5f);
        
            Configuring.CurrentURPA.MixedLighting(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
