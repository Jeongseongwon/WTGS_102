Shader "Custom/Simple Background" {
    Properties {
        _Color ("Main Color", Color) = (1,1,1,0)
    }

    SubShader {
        Pass {
            Material {
                Diffuse [_Color]
            }
            Lighting On
            Cull Off
        }
    }
}