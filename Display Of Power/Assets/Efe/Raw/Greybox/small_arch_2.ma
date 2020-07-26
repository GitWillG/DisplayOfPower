//Maya ASCII 2018 scene
//Name: small_arch_2.ma
//Last modified: Tue, Jul 21, 2020 06:22:15 PM
//Codeset: 1252
requires maya "2018";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2018";
fileInfo "version" "2018";
fileInfo "cutIdentifier" "201706261615-f9658c4cfc";
fileInfo "osv" "Microsoft Windows 8 Business Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -s -n "persp";
	rename -uid "22D0987A-4889-F782-3583-D49AE7D9CC34";
	setAttr ".v" no;
	setAttr ".t" -type "double3" -1.7401709320008685 8.4482473055777607 23.730023408883348 ;
	setAttr ".r" -type "double3" -18.33835272960161 7.4000000000006239 -4.0090843644937609e-16 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "DE7F2462-4476-148C-AE0E-9CB01090C217";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".coi" 26.105376776914603;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".tp" -type "double3" -4.9316765401120595 0.23476708335294671 -0.84320859785921365 ;
	setAttr ".hc" -type "string" "viewSet -p %camera";
	setAttr ".ai_translator" -type "string" "perspective";
createNode transform -s -n "top";
	rename -uid "E0E085D6-496C-9F7F-E97B-58A737586A91";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 1000.1 0 ;
	setAttr ".r" -type "double3" -89.999999999999986 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "C9EF6BFA-4164-AE78-E98D-3CAFDB93DB5C";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "front";
	rename -uid "668471AD-4E94-E849-752A-4BBDBCDFF591";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 1000.1 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "A13FF48E-4A01-6D6B-D330-4881C5AC10E6";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "side";
	rename -uid "B8F55022-408D-140F-AF43-7DBE069CBE32";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1000.1 0 0 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "54FEDF20-4DB6-D570-76E1-D19C0B73CB92";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -n "group";
	rename -uid "CE4C23BF-4FC9-EF1F-2536-5EB215D964E9";
	setAttr ".t" -type "double3" -10.822438392376464 -1.4291428287564283 -1.7584858405197361 ;
	setAttr ".rp" -type "double3" 12.214736088723292 2.378481388092041 1.7945201396942139 ;
	setAttr ".sp" -type "double3" 12.214736088723292 2.378481388092041 1.7945201396942139 ;
createNode transform -n "watercity_squad:directionalLight2" -p "group";
	rename -uid "A6D995EB-4DBA-7DB8-FE06-58AE97E83E94";
	setAttr ".rp" -type "double3" 26.331220986598908 13.910786676591304 6.4009027501918085 ;
	setAttr ".sp" -type "double3" 26.331220986598908 13.910786676591304 6.4009027501918085 ;
createNode transform -n "watercity_squad:polySurface56" -p "watercity_squad:directionalLight2";
	rename -uid "18624CC6-442E-DCD1-27A8-6F9FBFFF04CF";
	addAttr -is true -ci true -k true -sn "currentUVSet" -ln "currentUVSet" -dt "string";
	setAttr -k on ".currentUVSet" -type "string" "map1";
createNode transform -n "watercity_squad:transform125" -p "|group|watercity_squad:directionalLight2|watercity_squad:polySurface56";
	rename -uid "EA083D16-4A5A-9DE1-28DA-1BB0996D51D3";
	setAttr ".v" no;
createNode mesh -n "watercity_squad:polySurface56Shape" -p "watercity_squad:transform125";
	rename -uid "78C9B0B2-47B3-D64E-83A3-AAB94BE937F7";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".iog[0].og[0].gcl" -type "componentList" 1 "f[0:16]";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 28 ".uvst[0].uvsp[0:27]" -type "float2" 0.375 0 0.625 0 0.625
		 0.25 0.375 0.25 0.375 0.25 0.625 0.25 0.625 0.5 0.375 0.5 0.375 0.5 0.625 0.5 0.625
		 0.75 0.375 0.75 0.625 1 0.375 1 0.875 0 0.875 0.25 0.625 0.25 0.375 0.25 0.625 0.5
		 0.375 0.5 0.625 0.25 0.375 0.25 0.625 0.5 0.375 0.5 0.375 0.5 0.625 0.5 0.625 0.25
		 0.375 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr -s 24 ".vt[0:23]"  22.60396194 2.73720026 3.58904028 22.60396194 3.19218302 3.58904028
		 22.60396194 3.19218302 3.32012725 22.60396194 2.73720026 3.32012725 22.59163284 3.203161 3.5749042
		 22.59163284 3.203161 3.33426332 22.59163284 4.46591091 3.5749042 22.59163284 4.46591091 3.33426332
		 22.59163284 4.064960003 3.33426332 22.59163284 4.064960003 3.5749042 22.59163284 4.75696278 3.5749042
		 22.59163284 4.75696278 3.33426332 22.36943817 3.19218302 3.58904028 22.36943817 2.73720026 3.58904028
		 22.38176346 4.75696278 3.33426332 22.38176346 4.75696278 3.5749042 22.36943817 2.73720026 3.32012725
		 22.36943817 3.19218302 3.32012725 22.38176346 3.203161 3.5749042 22.38176346 3.203161 3.33426332
		 22.38176346 4.064960003 3.5749042 22.38176346 4.064960003 3.33426332 22.38176346 4.46591091 3.33426332
		 22.38176346 4.46591091 3.5749042;
	setAttr -s 40 ".ed[0:39]"  13 0 0 0 1 0 1 12 0 12 13 0 15 10 0 10 11 0
		 11 14 0 14 15 0 17 2 0 2 3 0 3 16 0 16 17 0 3 0 0 13 16 0 2 1 0 1 4 0 4 18 0 18 12 0
		 2 5 0 5 4 0 17 19 0 19 5 0 4 9 0 9 20 0 20 18 0 5 8 0 8 9 0 19 21 0 21 8 0 21 22 0
		 22 7 0 7 8 0 7 6 0 6 9 0 6 23 0 23 20 0 6 10 0 15 23 0 7 11 0 22 14 0;
	setAttr -s 68 ".n[0:67]" -type "float3"  0 0 1 0 0 1 0 0.0178778 0.99984026
		 0 0.017880432 0.99984008 0 1 0 0 1 0 0 1 0 0 1 0 0 0.017880486 -0.99984014 0 0.017877851
		 -0.99984026 0 0 -1 0 0 -1 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0.99999994 0 0 0.99999994 0
		 0 0.99990308 0.013922189 0 0.99990308 0.013922189 0 0 0.017880432 0.99984008 0 0.0178778
		 0.99984026 0 0.78980362 0.61335981 0 0.78980362 0.61335975 0.99990308 0.013922189
		 0 0.99990308 0.013922189 0 0.66502798 0.74681842 0 0.66502798 0.74681842 0 0 0.017877851
		 -0.99984026 0 0.017880486 -0.99984014 0 0.78980589 -0.61335689 0 0.78980595 -0.61335689
		 0 0 1 0 0 1 0 0 1 0 0 1 1 0 0 1 0 0 0.99999994 0 0 0.99999994 0 0 0 0 -1 0 0 -1 0
		 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0.99999994 0 0 0.99999994 0 0 1 0 0 1 0 0
		 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 1 0 0 1 0 0 1 0 0 1 0 0 0 0 -1 0
		 0 -1 0 0 -1 0 0 -1;
	setAttr -s 17 -ch 68 ".fc[0:16]" -type "polyFaces" 
		f 4 0 1 2 3
		mu 0 4 0 1 2 3
		f 4 4 5 6 7
		mu 0 4 4 5 6 7
		f 4 8 9 10 11
		mu 0 4 8 9 10 11
		f 4 -11 12 -1 13
		mu 0 4 11 10 12 13
		f 4 -13 -10 14 -2
		mu 0 4 1 14 15 2
		f 4 -3 15 16 17
		mu 0 4 3 2 16 17
		f 4 -15 18 19 -16
		mu 0 4 2 9 18 16
		f 4 -9 20 21 -19
		mu 0 4 9 8 19 18
		f 4 -17 22 23 24
		mu 0 4 17 16 20 21
		f 4 -20 25 26 -23
		mu 0 4 16 18 22 20
		f 4 -22 27 28 -26
		mu 0 4 18 19 23 22
		f 4 -29 29 30 31
		mu 0 4 22 23 24 25
		f 4 -27 -32 32 33
		mu 0 4 20 22 25 26
		f 4 -24 -34 34 35
		mu 0 4 21 20 26 27
		f 4 -35 36 -5 37
		mu 0 4 27 26 5 4
		f 4 -33 38 -6 -37
		mu 0 4 26 25 6 5
		f 4 -31 39 -7 -39
		mu 0 4 25 24 7 6;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "watercity_squad:polySurface57" -p "watercity_squad:directionalLight2";
	rename -uid "4A0E1DC3-4052-D9FB-C2D4-3EA7D13E5CE7";
	addAttr -is true -ci true -k true -sn "currentUVSet" -ln "currentUVSet" -dt "string";
	setAttr -k on ".currentUVSet" -type "string" "map1";
createNode transform -n "watercity_squad:transform124" -p "watercity_squad:polySurface57";
	rename -uid "127E9FCC-46CE-1FF6-49DB-C2BB4F86F161";
	setAttr ".v" no;
createNode mesh -n "watercity_squad:polySurface57Shape" -p "watercity_squad:transform124";
	rename -uid "121198E1-476B-8414-4281-5182FA8F13EF";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".iog[0].og[0].gcl" -type "componentList" 1 "f[0:82]";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 103 ".uvst[0].uvsp[0:102]" -type "float2" 0.125 0 0.375 0 0.375
		 0.25 0.125 0.25 0.375 0.5 0.375 0.25 0.375 0.5 0.375 0.25 0.375 0.5 0.375 0.25 0.375
		 0.5 0.375 0.25 0.375 0.25 0.375 0.25 0.375 0.5 0.375 0.5 0.375 0.25 0.375 0.5 0.375
		 0.5 0.375 0.5 0.375 0.5 0.375 0.5 0.375 0.5 0.375 0.5 0.375 0.5 0.375 0.25 0.375
		 0.25 0.375 0.25 0.375 0.25 0.375 0.25 0.375 0.25 0.375 0.5 0.375 0.5 0.375 0.5 0.375
		 0.25 0.375 0.25 0.375 0.25 0.375 0.5 0.375 0.5 0.375 0.5 0.375 0.25 0.375 0.25 0.375
		 0.25 0.375 0 0.375 0.25 0.625 0.25 0.625 0 0.375 0.25 0.375 0.5 0.625 0.5 0.625 0.25
		 0.375 0.5 0.375 0.75 0.625 0.75 0.625 0.5 0.375 1 0.625 1 0.875 0.25 0.875 0 0.125
		 0 0.125 0.25 0.375 0.25 0.625 0.25 0.625 0.5 0.375 0.5 0.375 0.25 0.625 0.25 0.625
		 0.5 0.375 0.5 0.625 0.5 0.375 0.5 0.625 0.25 0.375 0.25 0.375 0.5 0.375 0.25 0.375
		 0.25 0.375 0.25 0.375 0.5 0.375 0.5 0.375 0.5 0.375 0.5 0.375 0.5 0.375 0.5 0.375
		 0.5 0.375 0.5 0.375 0.25 0.375 0.25 0.375 0.25 0.375 0.25 0.375 0.25 0.375 0.25 0.375
		 0.5 0.375 0.5 0.375 0.5 0.375 0.25 0.375 0.25 0.375 0.25 0.375 0.5 0.375 0.5 0.375
		 0.5 0.375 0.25 0.375 0.25 0.375 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr -s 90 ".vt[0:89]"  22.36943817 2.73720026 3.58904028 22.36943817 3.19218302 3.58904028
		 22.36943817 3.19218302 3.32012725 22.36943817 2.73720026 3.32012725 22.38176346 3.203161 3.5749042
		 22.38176346 3.203161 3.33426332 22.38176346 4.46591091 3.5749042 22.38176346 4.46591091 3.33426332
		 22.38176346 4.064960003 3.33426332 22.38176346 4.064960003 3.5749042 22.38176346 4.75696278 3.5749042
		 22.38176346 4.75696278 3.33426332 21.92653656 4.39390612 3.33426332 21.92653656 4.46591091 3.33426332
		 21.92653656 4.75696278 3.33426332 21.92653656 4.75696278 3.5749042 21.92653656 4.46591091 3.5749042
		 21.92653656 4.39390612 3.5749042 22.037418365 4.37802744 3.33426332 22.037418365 4.46591091 3.33426332
		 22.037418365 4.75696278 3.33426332 22.037418365 4.75696278 3.5749042 22.037418365 4.46591091 3.5749042
		 22.037418365 4.37802744 3.5749042 22.14744949 4.30524635 3.33426332 22.14744949 4.46591091 3.33426332
		 22.14744949 4.75696278 3.33426332 22.14744949 4.75696278 3.5749042 22.14744949 4.46591091 3.5749042
		 22.14744949 4.30524635 3.5749042 22.25785828 4.20309782 3.33426332 22.25785828 4.46591091 3.33426332
		 22.25785828 4.75696278 3.33426332 22.25785828 4.75696278 3.5749042 22.25785828 4.46591091 3.5749042
		 22.25785828 4.20309782 3.5749042 21.83516502 4.36972094 3.33426332 21.83516502 4.46591091 3.33426332
		 21.83516502 4.75696278 3.33426332 21.83516502 4.75696278 3.5749042 21.83516502 4.46591091 3.5749042
		 21.83516502 4.36972094 3.5749042 21.30089378 2.73720026 3.58904028 21.06637001 2.73720026 3.58904028
		 21.30089378 3.19218302 3.58904028 21.06637001 3.19218302 3.58904028 21.30089378 3.19218302 3.32012725
		 21.06637001 3.19218302 3.32012725 21.30089378 2.73720026 3.32012725 21.06637001 2.73720026 3.32012725
		 21.28856468 3.203161 3.5749042 21.078697205 3.203161 3.5749042 21.078697205 3.203161 3.33426332
		 21.28856468 3.203161 3.33426332 21.28856468 4.46591091 3.5749042 21.078697205 4.46591091 3.5749042
		 21.078697205 4.46591091 3.33426332 21.28856468 4.46591091 3.33426332 21.28856468 4.064960003 3.33426332
		 21.078697205 4.064960003 3.33426332 21.078697205 4.064960003 3.5749042 21.28856468 4.064960003 3.5749042
		 21.28856468 4.75696278 3.5749042 21.078697205 4.75696278 3.5749042 21.078697205 4.75696278 3.33426332
		 21.28856468 4.75696278 3.33426332 21.74379349 4.39390612 3.33426332 21.74379349 4.46591091 3.33426332
		 21.74379349 4.75696278 3.33426332 21.74379349 4.75696278 3.5749042 21.74379349 4.46591091 3.5749042
		 21.74379349 4.39390612 3.5749042 21.63291168 4.37802744 3.33426332 21.63291168 4.46591091 3.33426332
		 21.63291168 4.75696278 3.33426332 21.63291168 4.75696278 3.5749042 21.63291168 4.46591091 3.5749042
		 21.63291168 4.37802744 3.5749042 21.52287865 4.30524635 3.33426332 21.52287865 4.46591091 3.33426332
		 21.52287865 4.75696278 3.33426332 21.52287865 4.75696278 3.5749042 21.52287865 4.46591091 3.5749042
		 21.52287865 4.30524635 3.5749042 21.41247177 4.20309782 3.33426332 21.41247177 4.46591091 3.33426332
		 21.41247177 4.75696278 3.33426332 21.41247177 4.75696278 3.5749042 21.41247177 4.46591091 3.5749042
		 21.41247177 4.20309782 3.5749042;
	setAttr -s 172 ".ed";
	setAttr ".ed[0:165]"  3 0 0 0 1 0 1 2 0 2 3 0 1 4 0 4 5 0 5 2 0 4 9 0 9 8 0
		 8 5 0 9 35 0 35 30 0 30 8 0 9 6 0 6 34 0 34 35 0 10 11 0 11 32 0 32 33 0 33 10 0
		 7 8 0 30 31 0 31 7 0 31 32 0 11 7 0 6 10 0 33 34 0 13 12 0 12 36 0 36 37 0 37 13 0
		 14 13 0 37 38 0 38 14 0 15 14 0 38 39 0 39 15 0 17 16 0 16 40 0 40 41 0 41 17 0 12 17 0
		 41 36 0 19 18 0 18 12 0 13 19 0 20 19 0 14 20 0 21 20 0 15 21 0 16 22 0 22 21 0 15 16 0
		 23 22 0 17 23 0 18 23 0 25 24 0 24 18 0 19 25 0 26 25 0 20 26 0 27 26 0 21 27 0 22 28 0
		 28 27 0 29 28 0 23 29 0 24 29 0 30 24 0 25 31 0 26 32 0 27 33 0 28 34 0 29 35 0 39 40 0
		 42 44 0 44 45 0 45 43 0 43 42 0 62 65 0 65 64 0 64 63 0 63 62 0 46 48 0 48 49 0 49 47 0
		 47 46 0 48 42 0 43 49 0 45 47 0 46 44 0 44 50 0 50 51 0 51 45 0 51 52 0 52 47 0 52 53 0
		 53 46 0 53 50 0 50 61 0 61 60 0 60 51 0 60 59 0 59 52 0 59 58 0 58 53 0 58 61 0 59 56 0
		 56 57 0 57 58 0 60 55 0 55 56 0 61 54 0 54 55 0 58 84 0 84 89 0 89 61 0 89 88 0 88 54 0
		 62 87 0 87 86 0 86 65 0 57 85 0 85 84 0 54 62 0 63 55 0 64 56 0 65 57 0 86 85 0 88 87 0
		 67 37 0 36 66 0 66 67 0 68 38 0 67 68 0 69 39 0 68 69 0 71 41 0 40 70 0 70 71 0 71 66 0
		 73 67 0 66 72 0 72 73 0 74 68 0 73 74 0 75 69 0 74 75 0 70 69 0 75 76 0 76 70 0 77 71 0
		 76 77 0 77 72 0 79 73 0 72 78 0 78 79 0 80 74 0 79 80 0 81 75 0 80 81 0 81 82 0 82 76 0
		 83 77 0 82 83 0 83 78 0;
	setAttr ".ed[166:171]" 85 79 0 78 84 0 86 80 0 87 81 0 88 82 0 89 83 0;
	setAttr -s 332 ".n";
	setAttr ".n[0:165]" -type "float3"  -0.99999994 0 0 -0.99999994 0 0 -0.99990314
		 0.013918597 0 -0.99990314 0.013918597 0 -0.99990314 0.013918597 0 -0.99990314 0.013918597
		 0 -0.6650914 0.74676204 0 -0.6650914 0.74676204 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0 -0.74441558
		 -0.6677165 0 -0.74441558 -0.6677165 0 -0.71594828 -0.69815338 0 -0.71594828 -0.69815338
		 0 7.2473119e-07 0 1 3.861168e-07 0 1 4.4917769e-07 0 1 8.1426037e-07 0 1 0 1 0 0
		 1 0 0 0.99999994 0 0 0.99999994 0 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0 -1
		 0 0 -1 4.4917769e-07 0 1 3.861168e-07 0 1 0 0 1 0 0 1 -1.9758973e-07 0 -1 -8.7288691e-07
		 0 -1 0 0 -1 0 0 -0.99999994 0 0 -1 -1.9758973e-07 0 -1 0 0 -0.99999994 0 0 -1 0 1
		 0 0 1 0 0 1 0 0 1 0 -4.6613016e-07 0 1 -9.8794857e-08 0 1 -1.0867892e-07 0 0.99999994
		 -4.8480433e-07 0 1 0.041034952 -0.99915773 0 0.041034952 -0.99915773 0 0 -1 0 0 -1
		 0 -1.716022e-07 0 -1 -5.052338e-07 0 -1 -8.7288691e-07 0 -1 -1.9758973e-07 0 -1 0
		 0 -1 -1.716022e-07 0 -1 -1.9758973e-07 0 -1 0 0 -1 0 1 0 0 1 0 0 1 0 0 1 0 -9.8794857e-08
		 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 -9.8794857e-08 0 1 -4.6613016e-07 0 1 -0.37245747
		 -0.92804933 0 -0.37245747 -0.92804933 0 0.041034952 -0.99915773 0 0.041034952 -0.99915773
		 0 0 0 -1 0 0 -1 -5.052338e-07 0 -1 -1.716022e-07 0 -1 0 0 -1 0 0 -1 -1.716022e-07
		 0 -1 0 0 -1 0 1 0 0 1 0 0 1 0 0 1 0 0 0 1 2.9445641e-07 0 1 0 0 1 0 0 1 1.0206861e-06
		 0 1 2.9445641e-07 0 1 0 0 1 0 0 1 -0.62160951 -0.78332734 0 -0.62160951 -0.78332734
		 0 -0.37245747 -0.92804933 0 -0.37245747 -0.92804933 0 0 0 -1 0 0 -1 0 0 -1 0 0 -1
		 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0.99999994 0 0 0.99999994 0 0 1 0 0 1 0 2.9445641e-07
		 0 1 4.4917769e-07 0 1 0 0 1 0 0 1 8.1426037e-07 0 1 4.4917769e-07 0 1 2.9445641e-07
		 0 1 1.0206861e-06 0 1 -0.71594828 -0.69815338 0 -0.71594828 -0.69815338 0 -0.62160951
		 -0.78332734 0 -0.62160951 -0.78332734 0 0 0 1 -1.0867892e-07 0 0.99999994 -9.8794857e-08
		 0 1 0 0 1 0 0 1 0 0.017877812 0.99984026 0 0.017879127 0.99984014 0 0 1 0 1 0 0 1
		 0 0 1 0 0 1 0 0 0.017877873 -0.99984026 0 0 -1 0 0 -1 0 0.01787919 -0.99984014 0
		 -1 0 0 -1 0 0 -1 0 0 -1 0 -0.99999994 0 0 -0.9999032 0.01392122 0 -0.9999032 0.01392122
		 0 -0.99999994 0 0 0.99999994 0 0 0.99990308 0.013922335 0 0.99990308 0.013922335
		 0 0.99999994 0 0 0 0.017877812 0.99984026 0 0.78980637 0.61335629 0 0.78980637 0.61335629
		 0 0.017879127 0.99984014 -0.9999032 0.01392122 0 -0.66502804 0.74681842 0 -0.66502804
		 0.74681842 0 -0.9999032 0.01392122 0 0 0.01787919 -0.99984014 0 0.78980637 -0.61335623;
	setAttr ".n[166:331]" -type "float3"  0 0.78980631 -0.61335629 0 0.017877873
		 -0.99984026 0.99990308 0.013922335 0 0.66502798 0.74681848 0 0.66502798 0.74681848
		 0 0.99990308 0.013922335 0 0 0 0.99999994 0 0 1 0 0 1 0 0 0.99999994 -1 0 0 -0.99999994
		 0 0 -0.99999994 0 0 -1 0 0 0 0 -0.99999994 0 0 -1 0 0 -1 0 0 -0.99999994 1 0 0 1
		 0 0 1 0 0 1 0 0 0 0 -1 0 0 -1 0 0 -1 0 0 -1 -0.99999994 0 0 -1 0 0 -1 0 0 -0.99999994
		 0 0 0 0 1 0 0 1 0 0 1 0 0 1 0.74441034 -0.66772246 0 0.71594834 -0.69815338 0 0.71594834
		 -0.69815338 0 0.74441034 -0.66772246 0 0 0 1 -4.1496014e-07 0 1 -4.4917712e-07 0
		 1 0 0 1 0 1 0 0 0.99999994 0 0 0.99999994 0 0 1 0 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0
		 1 0 0 1 0 0 1 0 0 1 -1 0 0 -1 0 0 -1 0 0 -1 0 0 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0 -1
		 0 0 -1 0 0 -0.99999994 0 0 -1 -4.4917712e-07 0 1 0 0 0.99999994 0 0 1 0 0 1 0 0 -1
		 0 0 -0.99999994 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0 -0.99999994 0 0 -1 0 1 0 0 1 0 0
		 1 0 0 1 0 0 0 1 -4.8480433e-07 0 1 -1.0867892e-07 0 0.99999994 0 0 1 -0.04103535
		 -0.99915773 0 0 -1 0 0 -1 0 -0.04103535 -0.99915773 0 0 0 -1 0 0 -1 0 0 -1 0 0 -0.99999994
		 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0.99999994 0 0 1 0 0 1 0 0 0.99999994 0 0 0 1 0 0 1
		 0 0 1 0 0 1 0 0 0.99999994 0 0 1 0 0 1 0 0 1 0.37245464 -0.9280504 0 -0.04103535
		 -0.99915773 0 -0.04103535 -0.99915773 0 0.37245464 -0.9280504 0 0 0 -1 0 0 -1 0 0
		 -0.99999994 0 0 -1 0 0 -0.99999994 0 0 -1 0 0 -1 0 0 -1 0 1 0 0 0.99999994 0 0 0.99999994
		 0 0 1 0 0 0 1 0 0 1 0 0 0.99999994 -5.8891396e-07 0 1 -2.0413927e-06 0 1 0 0 0.99999994
		 0 0 1 -5.8891396e-07 0 1 0.62160951 -0.78332728 0 0.37245464 -0.9280504 0 0.37245464
		 -0.9280504 0 0.62160951 -0.78332728 0 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0 -0.99999994
		 0 0 -0.99999994 0 0 -1 0 0 -1 0 0.99999994 0 0 1 0 0 1 0 0 0.99999994 0 -5.8891396e-07
		 0 1 0 0 0.99999994 0 0 0.99999994 -4.4917712e-07 0 1 -4.1496014e-07 0 1 -2.0413927e-06
		 0 1 -5.8891396e-07 0 1 -4.4917712e-07 0 1 0.71594834 -0.69815338 0 0.62160951 -0.78332728
		 0 0.62160951 -0.78332728 0 0.71594834 -0.69815338 0 0 0 1 0 0 1 0 0 1 -1.0867892e-07
		 0 0.99999994;
	setAttr -s 83 -ch 332 ".fc[0:82]" -type "polyFaces" 
		f 4 0 1 2 3
		mu 0 4 0 1 2 3
		f 4 -3 4 5 6
		mu 0 4 4 2 5 6
		f 4 -6 7 8 9
		mu 0 4 6 5 7 8
		f 4 -9 10 11 12
		mu 0 4 8 7 9 10
		f 4 13 14 15 -11
		mu 0 4 7 11 12 9
		f 4 16 17 18 19
		mu 0 4 13 14 15 16
		f 4 20 -13 21 22
		mu 0 4 17 8 10 18
		f 4 -23 23 -18 24
		mu 0 4 17 18 15 14
		f 4 -15 25 -20 26
		mu 0 4 12 11 13 16
		f 4 27 28 29 30
		mu 0 4 19 20 21 22
		f 4 31 -31 32 33
		mu 0 4 23 19 22 24
		f 4 34 -34 35 36
		mu 0 4 25 23 24 26
		f 4 37 38 39 40
		mu 0 4 27 28 29 30
		f 4 41 -41 42 -29
		mu 0 4 20 27 30 21
		f 4 43 44 -28 45
		mu 0 4 31 32 20 19
		f 4 46 -46 -32 47
		mu 0 4 33 31 19 23
		f 4 48 -48 -35 49
		mu 0 4 34 33 23 25
		f 4 50 51 -50 52
		mu 0 4 28 35 34 25
		f 4 53 -51 -38 54
		mu 0 4 36 35 28 27
		f 4 55 -55 -42 -45
		mu 0 4 32 36 27 20
		f 4 56 57 -44 58
		mu 0 4 37 38 32 31
		f 4 59 -59 -47 60
		mu 0 4 39 37 31 33
		f 4 61 -61 -49 62
		mu 0 4 40 39 33 34
		f 4 63 64 -63 -52
		mu 0 4 35 41 40 34
		f 4 65 -64 -54 66
		mu 0 4 42 41 35 36
		f 4 67 -67 -56 -58
		mu 0 4 38 42 36 32
		f 4 -22 68 -57 69
		mu 0 4 18 10 38 37
		f 4 -24 -70 -60 70
		mu 0 4 15 18 37 39
		f 4 -19 -71 -62 71
		mu 0 4 16 15 39 40
		f 4 72 -27 -72 -65
		mu 0 4 41 12 16 40
		f 4 -16 -73 -66 73
		mu 0 4 9 12 41 42
		f 4 -12 -74 -68 -69
		mu 0 4 10 9 42 38
		f 4 74 -39 -53 -37
		mu 0 4 26 29 28 25
		f 4 75 76 77 78
		mu 0 4 43 44 45 46
		f 4 79 80 81 82
		mu 0 4 47 48 49 50
		f 4 83 84 85 86
		mu 0 4 51 52 53 54
		f 4 87 -79 88 -85
		mu 0 4 52 55 56 53
		f 4 -78 89 -86 -89
		mu 0 4 46 45 57 58
		f 4 -84 90 -76 -88
		mu 0 4 59 60 44 43
		f 4 91 92 93 -77
		mu 0 4 44 61 62 45
		f 4 -94 94 95 -90
		mu 0 4 45 62 63 54
		f 4 -96 96 97 -87
		mu 0 4 54 63 64 51
		f 4 -98 98 -92 -91
		mu 0 4 51 64 61 44
		f 4 99 100 101 -93
		mu 0 4 61 65 66 62
		f 4 -102 102 103 -95
		mu 0 4 62 66 67 63
		f 4 -104 104 105 -97
		mu 0 4 63 67 68 64
		f 4 -106 106 -100 -99
		mu 0 4 64 68 65 61
		f 4 107 108 109 -105
		mu 0 4 67 69 70 68
		f 4 110 111 -108 -103
		mu 0 4 66 71 69 67
		f 4 112 113 -111 -101
		mu 0 4 65 72 71 66
		f 4 114 115 116 -107
		mu 0 4 68 73 74 65
		f 4 -117 117 118 -113
		mu 0 4 65 74 75 72
		f 4 119 120 121 -80
		mu 0 4 47 76 77 48
		f 4 122 123 -115 -110
		mu 0 4 70 78 73 68
		f 4 124 -83 125 -114
		mu 0 4 72 47 50 71
		f 4 -126 -82 126 -112
		mu 0 4 71 50 49 69
		f 4 -127 -81 127 -109
		mu 0 4 69 49 48 70
		f 4 -128 -122 128 -123
		mu 0 4 70 48 77 78
		f 4 129 -120 -125 -119
		mu 0 4 75 76 47 72
		f 4 130 -30 131 132
		mu 0 4 79 80 81 82
		f 4 133 -33 -131 134
		mu 0 4 83 84 80 79
		f 4 135 -36 -134 136
		mu 0 4 85 86 84 83
		f 4 137 -40 138 139
		mu 0 4 87 88 89 90
		f 4 -132 -43 -138 140
		mu 0 4 82 81 88 87
		f 4 141 -133 142 143
		mu 0 4 91 79 82 92
		f 4 144 -135 -142 145
		mu 0 4 93 83 79 91
		f 4 146 -137 -145 147
		mu 0 4 94 85 83 93
		f 4 148 -147 149 150
		mu 0 4 90 85 94 95
		f 4 151 -140 -151 152
		mu 0 4 96 87 90 95
		f 4 -143 -141 -152 153
		mu 0 4 92 82 87 96
		f 4 154 -144 155 156
		mu 0 4 97 91 92 98
		f 4 157 -146 -155 158
		mu 0 4 99 93 91 97
		f 4 159 -148 -158 160
		mu 0 4 100 94 93 99
		f 4 -150 -160 161 162
		mu 0 4 95 94 100 101
		f 4 163 -153 -163 164
		mu 0 4 102 96 95 101
		f 4 -156 -154 -164 165
		mu 0 4 98 92 96 102
		f 4 166 -157 167 -124
		mu 0 4 78 97 98 73
		f 4 168 -159 -167 -129
		mu 0 4 77 99 97 78
		f 4 169 -161 -169 -121
		mu 0 4 76 100 99 77
		f 4 -162 -170 -130 170
		mu 0 4 101 100 76 75
		f 4 171 -165 -171 -118
		mu 0 4 74 102 101 75
		f 4 -168 -166 -172 -116
		mu 0 4 73 98 102 74
		f 4 -136 -149 -139 -75
		mu 0 4 86 85 90 89;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "watercity_squad:polySurface56" -p "group";
	rename -uid "334FC284-4952-0C44-1B9F-28A66125ECA4";
	setAttr ".rp" -type "double3" 21.835165977478027 3.7470815181732178 3.4545837640762329 ;
	setAttr ".sp" -type "double3" 21.835165977478027 3.7470815181732178 3.4545837640762329 ;
createNode mesh -n "watercity_squad:polySurface56Shape" -p "|group|watercity_squad:polySurface56";
	rename -uid "04FE1FBE-4743-424F-E676-238711CA80A8";
	setAttr -k off ".v";
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode lightLinker -s -n "lightLinker1";
	rename -uid "33DE24A3-4050-29AC-3886-C8AC966D7240";
	setAttr -s 3 ".lnk";
	setAttr -s 3 ".slnk";
createNode shapeEditorManager -n "shapeEditorManager";
	rename -uid "39C40517-46F2-3FB0-149F-18A5FC6D7E60";
createNode poseInterpolatorManager -n "poseInterpolatorManager";
	rename -uid "A28D7879-415C-F11D-E2DA-9FB1D396703F";
createNode displayLayerManager -n "layerManager";
	rename -uid "98ECEBFD-483D-7EBA-9287-FDB78E55010F";
createNode displayLayer -n "defaultLayer";
	rename -uid "BCE9167A-4E1B-3A4D-A3D1-999A4264AF1A";
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "619BBA44-43F3-2208-370E-0F81639E2917";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "81AEA385-4BB2-47BE-0A2B-648FE98EAA04";
	setAttr ".g" yes;
createNode groupParts -n "watercity_squad:groupParts1";
	rename -uid "136974B1-429B-E114-870D-BE9BF810CF79";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:99]";
createNode polyUnite -n "pasted__polyUnite1";
	rename -uid "05725EBA-4A76-A39A-5080-6C82193EACDF";
	setAttr -s 2 ".ip";
	setAttr -s 2 ".im";
createNode groupId -n "watercity_squad:groupId1";
	rename -uid "5C7074B6-47A9-B79E-6E7A-DBB5678ED5BF";
	setAttr ".ihi" 0;
createNode shadingEngine -n "watercity_squad:pPlane14SG";
	rename -uid "3167E799-4EA9-40E8-D987-4887D2F6E949";
	setAttr ".ihi" 0;
	setAttr -s 5 ".dsm";
	setAttr ".ro" yes;
	setAttr -s 5 ".gn";
createNode materialInfo -n "pasted__materialInfo1";
	rename -uid "9F0E80DB-44CB-3814-0189-E48ABA670875";
createNode lambert -n "pasted__lambert2";
	rename -uid "F34E3340-4351-5BAD-981B-76B0FE81E949";
createNode groupId -n "watercity_squad:groupId2";
	rename -uid "F182943C-449B-A10B-7830-528C3C143881";
	setAttr ".ihi" 0;
createNode groupId -n "watercity_squad:groupId3";
	rename -uid "9F303F51-4CEA-4FFD-3263-7597CA33092E";
	setAttr ".ihi" 0;
createNode groupId -n "watercity_squad:groupId4";
	rename -uid "8378A74B-4D59-B529-24F6-C6A9637A4F5C";
	setAttr ".ihi" 0;
createNode groupId -n "watercity_squad:groupId5";
	rename -uid "DA62A159-4ACF-FA31-CFAE-8995498D46BE";
	setAttr ".ihi" 0;
createNode script -n "uiConfigurationScriptNode";
	rename -uid "4CC05152-4CA8-277C-CB78-429CE57A642A";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n"
		+ "            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n"
		+ "            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n"
		+ "            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n"
		+ "            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n"
		+ "            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n"
		+ "            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n"
		+ "            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n"
		+ "            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n"
		+ "            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n"
		+ "            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n"
		+ "            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1315\n            -height 698\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"ToggledOutliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"ToggledOutliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 1\n            -showReferenceMembers 1\n            -showAttributes 0\n"
		+ "            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -isSet 0\n            -isSetMember 0\n"
		+ "            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            -renderFilterIndex 0\n            -selectionOrder \"chronological\" \n            -expandAttribute 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n"
		+ "            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n"
		+ "                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n"
		+ "                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 1\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -showCurveNames 0\n"
		+ "                -showActiveCurveNames 0\n                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                -valueLinesToggle 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n"
		+ "                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n"
		+ "                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n"
		+ "                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"timeEditorPanel\" (localizedPanelLabel(\"Time Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Time Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n"
		+ "                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n"
		+ "                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" != $panelName) {\n"
		+ "\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n"
		+ "                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -highlightConnections 0\n                -copyConnectionsOnPaste 0\n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -activeTab -1\n                -editorMode \"default\" \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"shapePanel\" (localizedPanelLabel(\"Shape Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tshapePanel -edit -l (localizedPanelLabel(\"Shape Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"posePanel\" (localizedPanelLabel(\"Pose Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tposePanel -edit -l (localizedPanelLabel(\"Pose Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"componentEditorPanel\" (localizedPanelLabel(\"Component Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"contentBrowserPanel\" (localizedPanelLabel(\"Content Browser\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Content Browser\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-userCreated false\n\t\t\t\t-defaultImage \"vacantCell.xP:/\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1315\\n    -height 698\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1315\\n    -height 698\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "2F5FFAEB-439E-022A-5BED-1482595DDB5B";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 120 -ast 1 -aet 200 ";
	setAttr ".st" 6;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 3 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 5 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultRenderGlobals;
	setAttr ".ren" -type "string" "arnold";
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "watercity_squad:groupId1.id" "|group|watercity_squad:directionalLight2|watercity_squad:polySurface56|watercity_squad:transform125|watercity_squad:polySurface56Shape.iog.og[0].gid"
		;
connectAttr "watercity_squad:pPlane14SG.mwc" "|group|watercity_squad:directionalLight2|watercity_squad:polySurface56|watercity_squad:transform125|watercity_squad:polySurface56Shape.iog.og[0].gco"
		;
connectAttr "watercity_squad:groupId2.id" "|group|watercity_squad:directionalLight2|watercity_squad:polySurface56|watercity_squad:transform125|watercity_squad:polySurface56Shape.ciog.cog[0].cgid"
		;
connectAttr "watercity_squad:groupId3.id" "watercity_squad:polySurface57Shape.iog.og[0].gid"
		;
connectAttr "watercity_squad:pPlane14SG.mwc" "watercity_squad:polySurface57Shape.iog.og[0].gco"
		;
connectAttr "watercity_squad:groupId4.id" "watercity_squad:polySurface57Shape.ciog.cog[0].cgid"
		;
connectAttr "watercity_squad:groupParts1.og" "|group|watercity_squad:polySurface56|watercity_squad:polySurface56Shape.i"
		;
connectAttr "watercity_squad:groupId5.id" "|group|watercity_squad:polySurface56|watercity_squad:polySurface56Shape.iog.og[0].gid"
		;
connectAttr "watercity_squad:pPlane14SG.mwc" "|group|watercity_squad:polySurface56|watercity_squad:polySurface56Shape.iog.og[0].gco"
		;
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "watercity_squad:pPlane14SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "watercity_squad:pPlane14SG.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "pasted__polyUnite1.out" "watercity_squad:groupParts1.ig";
connectAttr "watercity_squad:groupId5.id" "watercity_squad:groupParts1.gi";
connectAttr "|group|watercity_squad:directionalLight2|watercity_squad:polySurface56|watercity_squad:transform125|watercity_squad:polySurface56Shape.o" "pasted__polyUnite1.ip[0]"
		;
connectAttr "watercity_squad:polySurface57Shape.o" "pasted__polyUnite1.ip[1]";
connectAttr "|group|watercity_squad:directionalLight2|watercity_squad:polySurface56|watercity_squad:transform125|watercity_squad:polySurface56Shape.wm" "pasted__polyUnite1.im[0]"
		;
connectAttr "watercity_squad:polySurface57Shape.wm" "pasted__polyUnite1.im[1]";
connectAttr "pasted__lambert2.oc" "watercity_squad:pPlane14SG.ss";
connectAttr "|group|watercity_squad:directionalLight2|watercity_squad:polySurface56|watercity_squad:transform125|watercity_squad:polySurface56Shape.iog.og[0]" "watercity_squad:pPlane14SG.dsm"
		 -na;
connectAttr "|group|watercity_squad:directionalLight2|watercity_squad:polySurface56|watercity_squad:transform125|watercity_squad:polySurface56Shape.ciog.cog[0]" "watercity_squad:pPlane14SG.dsm"
		 -na;
connectAttr "watercity_squad:polySurface57Shape.iog.og[0]" "watercity_squad:pPlane14SG.dsm"
		 -na;
connectAttr "watercity_squad:polySurface57Shape.ciog.cog[0]" "watercity_squad:pPlane14SG.dsm"
		 -na;
connectAttr "|group|watercity_squad:polySurface56|watercity_squad:polySurface56Shape.iog.og[0]" "watercity_squad:pPlane14SG.dsm"
		 -na;
connectAttr "watercity_squad:groupId1.msg" "watercity_squad:pPlane14SG.gn" -na;
connectAttr "watercity_squad:groupId2.msg" "watercity_squad:pPlane14SG.gn" -na;
connectAttr "watercity_squad:groupId3.msg" "watercity_squad:pPlane14SG.gn" -na;
connectAttr "watercity_squad:groupId4.msg" "watercity_squad:pPlane14SG.gn" -na;
connectAttr "watercity_squad:groupId5.msg" "watercity_squad:pPlane14SG.gn" -na;
connectAttr "watercity_squad:pPlane14SG.msg" "pasted__materialInfo1.sg";
connectAttr "pasted__lambert2.msg" "pasted__materialInfo1.m";
connectAttr "watercity_squad:pPlane14SG.pa" ":renderPartition.st" -na;
connectAttr "pasted__lambert2.msg" ":defaultShaderList1.s" -na;
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
// End of small_arch_2.ma
