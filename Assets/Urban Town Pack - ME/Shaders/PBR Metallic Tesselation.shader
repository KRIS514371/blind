// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "FlamingSands/PBR Metallic Tesselation"
{
	Properties
	{
		_Layer1Tiling("Layer 1 Tiling", Float) = 1
		[NoScaleOffset]_Albedo("Albedo", 2D) = "white" {}
		_Glossiness("Glossiness", Float) = 1
		_Metallic("Metallic", Float) = 1
		[NoScaleOffset]_RMA("RMA", 2D) = "white" {}
		[NoScaleOffset][Normal]_Normal("Normal", 2D) = "bump" {}
		_TessValue( "Max Tessellation", Range( 1, 32 ) ) = 32
		_TessMin( "Tess Min Distance", Float ) = 1
		_TessMax( "Tess Max Distance", Float ) = 10
		_TessPhongStrength( "Phong Tess Strength", Range( 0, 1 ) ) = 0.5
		_TessellationBias("Tessellation Bias", Range( -1 , 1)) = 0
		_TessellationHeight("Tessellation Height", Range( 0 , 1)) = 0.05
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#include "Tessellation.cginc"
		#pragma target 5.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows vertex:vertexDataFunc tessellate:tessFunction tessphong:_TessPhongStrength 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float _TessellationBias;
		uniform sampler2D _RMA;
		uniform float _Layer1Tiling;
		uniform float _TessellationHeight;
		uniform sampler2D _Normal;
		uniform sampler2D _Albedo;
		uniform float _Metallic;
		uniform float _Glossiness;
		uniform float _TessValue;
		uniform float _TessMin;
		uniform float _TessMax;
		uniform float _TessPhongStrength;

		float4 tessFunction( appdata_full v0, appdata_full v1, appdata_full v2 )
		{
			return UnityDistanceBasedTess( v0.vertex, v1.vertex, v2.vertex, _TessMin, _TessMax, _TessValue );
		}

		void vertexDataFunc( inout appdata_full v )
		{
			float2 temp_cast_0 = (_Layer1Tiling).xx;
			float2 uv_TexCoord211 = v.texcoord.xy * temp_cast_0;
			float4 tex2DNode32 = tex2Dlod( _RMA, float4( uv_TexCoord211, 0, 1.0) );
			float3 ase_vertexNormal = v.normal.xyz;
			v.vertex.xyz += ( ( ( _TessellationBias + tex2DNode32.a ) * ase_vertexNormal ) * _TessellationHeight );
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 temp_cast_0 = (_Layer1Tiling).xx;
			float2 uv_TexCoord211 = i.uv_texcoord * temp_cast_0;
			o.Normal = UnpackNormal( tex2D( _Normal, uv_TexCoord211 ) );
			o.Albedo = tex2D( _Albedo, uv_TexCoord211 ).rgb;
			float4 tex2DNode32 = tex2D( _RMA, uv_TexCoord211 );
			o.Metallic = ( tex2DNode32.g * _Metallic );
			o.Smoothness = ( tex2DNode32.r * _Glossiness );
			o.Occlusion = tex2DNode32.b;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=15311
-1907;42;1906;1004;430.6674;-860.8145;1;True;True
Node;AmplifyShaderEditor.RangedFloatNode;76;-1259.547,93.74462;Float;False;Property;_Layer1Tiling;Layer 1 Tiling;0;0;Create;True;0;0;False;0;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;211;-1003.056,83.91405;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;32;-254.562,27.55522;Float;True;Property;_RMA;RMA;4;1;[NoScaleOffset];Create;True;0;0;False;0;None;a163ec7e8b950d740aa608781d1d75a8;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;252;128.7858,1111.733;Float;False;Property;_TessellationBias;Tessellation Bias;11;0;Create;True;0;0;False;0;0;0;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;254;415.0849,1290.433;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NormalVertexDataNode;255;145.9865,1496.434;Float;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;256;525.8859,1355.533;Float;False;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;257;480.3847,1580.434;Float;False;Property;_TessellationHeight;Tessellation Height;12;0;Create;True;0;0;False;0;0.05;0.05;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;2;-206.562,315.5551;Float;False;Property;_Metallic;Metallic;3;0;Create;True;0;0;False;0;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;13;-206.562,234.2552;Float;False;Property;_Glossiness;Glossiness;2;0;Create;True;0;0;False;0;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;890.0382,127.4552;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;258;755.9846,1473.834;Float;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;33;893.0382,228.4551;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;7;-205.562,427.5551;Float;True;Property;_Normal;Normal;5;2;[NoScaleOffset];[Normal];Create;True;0;0;False;0;None;4f9f85d7e74333c409a45194036817d7;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;-254.562,-180.4449;Float;True;Property;_Albedo;Albedo;1;1;[NoScaleOffset];Create;True;0;0;False;0;None;d5133c1bf7a2a7946b37a585b7d6c475;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;1955.711,114.7165;Float;False;True;7;Float;ASEMaterialInspector;0;0;Standard;FlamingSands/PBR Metallic Tesselation;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;True;0;32;1;10;True;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;6;0;0;0;False;0;0;0;False;-1;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;211;0;76;0
WireConnection;32;1;211;0
WireConnection;254;0;252;0
WireConnection;254;1;32;4
WireConnection;256;0;254;0
WireConnection;256;1;255;0
WireConnection;12;0;32;1
WireConnection;12;1;13;0
WireConnection;258;0;256;0
WireConnection;258;1;257;0
WireConnection;33;0;32;2
WireConnection;33;1;2;0
WireConnection;7;1;211;0
WireConnection;1;1;211;0
WireConnection;0;0;1;0
WireConnection;0;1;7;0
WireConnection;0;3;33;0
WireConnection;0;4;12;0
WireConnection;0;5;32;3
WireConnection;0;11;258;0
ASEEND*/
//CHKSM=12A754FA65D3DE1E2A75144EA75D1236BCE6E3EC