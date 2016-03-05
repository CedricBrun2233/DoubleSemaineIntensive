// Upgrade NOTE: commented out 'float4 unity_DynamicLightmapST', a built-in variable
// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable

// Shader created with Shader Forge v1.03 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.03;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,dith:2,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.3537764,fgcg:0.3352076,fgcb:0.3676471,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:9722,x:33100,y:32844,varname:node_9722,prsc:2|diff-5044-OUT,emission-8590-OUT;n:type:ShaderForge.SFN_Tex2d,id:1287,x:32256,y:32616,ptovrint:False,ptlb:BaseTexture,ptin:_BaseTexture,varname:node_1287,prsc:2,tex:a6a583bbda818d84a9235f22fab6aeef,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9377,x:32244,y:33048,ptovrint:False,ptlb:Emissive,ptin:_Emissive,varname:node_9377,prsc:2,tex:a45a73599d70b7b4780c7c1511577895,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7409,x:32244,y:32821,ptovrint:False,ptlb:NormalMap,ptin:_NormalMap,varname:node_7409,prsc:2,tex:2401428f0cc90574a9c85b79d7ebec43,ntxv:3,isnm:True;n:type:ShaderForge.SFN_FragmentPosition,id:4664,x:31763,y:33173,varname:node_4664,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5859,x:32116,y:33285,varname:node_5859,prsc:2|A-4664-Y,B-2344-OUT;n:type:ShaderForge.SFN_Vector1,id:2344,x:31787,y:33436,varname:node_2344,prsc:2,v1:0.01;n:type:ShaderForge.SFN_ConstantClamp,id:2213,x:32437,y:33293,varname:node_2213,prsc:2,min:0,max:1|IN-5859-OUT;n:type:ShaderForge.SFN_Lerp,id:5044,x:32690,y:32738,varname:node_5044,prsc:2|A-1287-RGB,B-1917-RGB,T-2213-OUT;n:type:ShaderForge.SFN_Color,id:1917,x:32276,y:32419,ptovrint:False,ptlb:node_1917,ptin:_node_1917,varname:node_1917,prsc:2,glob:False,c1:0.2099899,c2:0,c3:0.7426471,c4:1;n:type:ShaderForge.SFN_Multiply,id:8590,x:32801,y:32998,varname:node_8590,prsc:2|A-9377-R,B-1931-OUT;n:type:ShaderForge.SFN_Slider,id:1931,x:32394,y:33150,ptovrint:False,ptlb:Emission,ptin:_Emission,varname:node_1931,prsc:2,min:0,cur:1,max:20;n:type:ShaderForge.SFN_Tex2d,id:5023,x:31138,y:34382,varname:node_8309,prsc:2,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-650-UVOUT,TEX-4408-TEX;n:type:ShaderForge.SFN_Multiply,id:7784,x:31514,y:34363,varname:node_7784,prsc:2|A-5023-RGB,B-1872-OUT;n:type:ShaderForge.SFN_Vector3,id:1872,x:31327,y:34539,varname:node_1872,prsc:2,v1:0,v2:1,v3:0;n:type:ShaderForge.SFN_Panner,id:650,x:30847,y:34403,varname:node_650,prsc:2,spu:0,spv:0;n:type:ShaderForge.SFN_TexCoord,id:3199,x:30207,y:34400,varname:node_3199,prsc:2,uv:0;n:type:ShaderForge.SFN_Vector2,id:2199,x:30225,y:34605,varname:node_2199,prsc:2,v1:0.2,v2:0.2;n:type:ShaderForge.SFN_Multiply,id:1209,x:30384,y:34400,varname:node_1209,prsc:2|A-3199-UVOUT,B-2199-OUT;n:type:ShaderForge.SFN_Panner,id:9684,x:30881,y:34877,varname:node_9684,prsc:2,spu:0.05,spv:0.07;n:type:ShaderForge.SFN_TexCoord,id:2383,x:30241,y:34874,varname:node_2383,prsc:2,uv:0;n:type:ShaderForge.SFN_Vector2,id:3011,x:30259,y:35079,varname:node_3011,prsc:2,v1:2,v2:2;n:type:ShaderForge.SFN_Multiply,id:4540,x:30418,y:34874,varname:node_4540,prsc:2|A-2383-UVOUT,B-3011-OUT;n:type:ShaderForge.SFN_Tex2d,id:2846,x:31164,y:34863,varname:node_2501,prsc:2,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-9684-UVOUT,TEX-4408-TEX;n:type:ShaderForge.SFN_Multiply,id:4200,x:31528,y:34887,varname:node_4200,prsc:2|A-2846-RGB,B-8902-OUT;n:type:ShaderForge.SFN_Vector3,id:8902,x:31341,y:35063,varname:node_8902,prsc:2,v1:0,v2:0.3,v3:0;n:type:ShaderForge.SFN_Multiply,id:4104,x:31823,y:34392,varname:node_4104,prsc:2|A-7784-OUT,B-4200-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:4408,x:30726,y:34627,ptovrint:False,ptlb:node_4814_copy,ptin:_node_4814_copy,varname:node_4814,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False;proporder:7409-9377-1287-1917-1931;pass:END;sub:END;*/

Shader "Shader Forge/Batiments" {
    Properties {
        _NormalMap ("NormalMap", 2D) = "bump" {}
        _Emissive ("Emissive", 2D) = "white" {}
        _BaseTexture ("BaseTexture", 2D) = "white" {}
        _node_1917 ("node_1917", Color) = (0.2099899,0,0.7426471,1)
        _Emission ("Emission", Range(0, 20)) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 3x3 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither3x3( float value, float2 sceneUVs ) {
                float3x3 mtx = float3x3(
                    float3( 3,  7,  4 )/10.0,
                    float3( 6,  1,  9 )/10.0,
                    float3( 2,  8,  5 )/10.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,3);
                int ySmp = fmod(px.y,3);
                float3 xVec = 1-saturate(abs(float3(0,1,2) - xSmp));
                float3 yVec = 1-saturate(abs(float3(0,1,2) - ySmp));
                float3 pxMult = float3( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            uniform float4 _LightColor0;
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform sampler2D _BaseTexture; uniform float4 _BaseTexture_ST;
            uniform sampler2D _Emissive; uniform float4 _Emissive_ST;
            uniform float4 _node_1917;
            uniform float _Emission;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 screenPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD7;
                #else
                    float3 shLight : TEXCOORD7;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(_Object2World, float4(v.normal,0)).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
/////// Vectors:
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 indirectDiffuse = float3(0,0,0);
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _BaseTexture_var = tex2D(_BaseTexture,TRANSFORM_TEX(i.uv0, _BaseTexture));
                float3 diffuse = (directDiffuse + indirectDiffuse) * lerp(_BaseTexture_var.rgb,_node_1917.rgb,clamp((i.posWorld.g*0.01),0,1));
////// Emissive:
                float4 _Emissive_var = tex2D(_Emissive,TRANSFORM_TEX(i.uv0, _Emissive));
                float node_8590 = (_Emissive_var.r*_Emission);
                float3 emissive = float3(node_8590,node_8590,node_8590);
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 3x3 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither3x3( float value, float2 sceneUVs ) {
                float3x3 mtx = float3x3(
                    float3( 3,  7,  4 )/10.0,
                    float3( 6,  1,  9 )/10.0,
                    float3( 2,  8,  5 )/10.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,3);
                int ySmp = fmod(px.y,3);
                float3 xVec = 1-saturate(abs(float3(0,1,2) - xSmp));
                float3 yVec = 1-saturate(abs(float3(0,1,2) - ySmp));
                float3 pxMult = float3( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            uniform float4 _LightColor0;
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform sampler2D _BaseTexture; uniform float4 _BaseTexture_ST;
            uniform sampler2D _Emissive; uniform float4 _Emissive_ST;
            uniform float4 _node_1917;
            uniform float _Emission;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 screenPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD6;
                #else
                    float3 shLight : TEXCOORD6;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(_Object2World, float4(v.normal,0)).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.screenPos = o.pos;
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
/////// Vectors:
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _BaseTexture_var = tex2D(_BaseTexture,TRANSFORM_TEX(i.uv0, _BaseTexture));
                float3 diffuse = directDiffuse * lerp(_BaseTexture_var.rgb,_node_1917.rgb,clamp((i.posWorld.g*0.01),0,1));
/// Final Color:
                float3 finalColor = diffuse;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
