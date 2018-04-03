module Tests.Encode

open Thot.Bson.Net.Encode
open Util.Testing

let tests : Test =
    testList "Thot.Json.Encode" [

        testList "Basic" [

            testCase "a string works" <| fun _ ->
                let expected = "\"maxime\""
                let actual =
                    string "maxime"
                    |> encode
                equal expected actual

            testCase "an int works" <| fun _ ->
                let expected = "1"
                let actual =
                    int 1
                    |> encode
                equal expected actual

            testCase "a float works" <| fun _ ->
                let expected = "1.2"
                let actual =
                    float 1.2
                    |> encode
                equal expected actual

            testCase "an array works" <| fun _ ->
                let expected =
                    """["maxime", 2]"""
                let actual =
                    array
                        [| string "maxime"
                           int 2
                        |] |> encode
                equal expected actual

            testCase "a list works" <| fun _ ->
                let expected =
                    """["maxime", 2]"""
                let actual =
                    list
                        [ string "maxime"
                          int 2
                        ] |> encode
                equal expected actual

            testCase "a bool works" <| fun _ ->
                let expected = "false"
                let actual =
                    bool false
                    |> encode
                equal expected actual

            testCase "a null works" <| fun _ ->
                let expected = "null"
                let actual =
                    nil
                    |> encode
                equal expected actual

            testCase "an object works" <| fun _ ->
                let expected =
                    """{ "firstname" : "maxime", "age" : 25 }"""
                let actual =
                    object
                        [ ("firstname", string "maxime")
                          ("age", int 25)
                        ] |> encode
                equal expected actual

            testCase "a dict works" <| fun _ ->
                let expected =
                    """{ "a" : 1, "b" : 2, "c" : 3 }"""
                let actual =
                    Map.ofList
                        [ ("a", int 1)
                          ("b", int 2)
                          ("c", int 3)
                        ]
                    |> dict
                    |> encode
                equal expected actual

            ptestCase "using pretty space works" <| fun _ ->
                let expected = "{\n    \"firstname\": \"maxime\",\n    \"age\": 25\n}"

                let actual =
                    object
                        [ ("firstname", string "maxime")
                          ("age", int 25)
                        ] |> encode
                equal expected actual

            ptestCase "complexe structure works" <| fun _ ->
                let expected =
                    "{\n    \"firstname\": \"maxime\",\n    \"age\": 25,\n    \"address\": {\n        \"street\": \"main road\",\n        \"city\": \"Bordeaux\"\n    }\n}"

                let actual =
                    object
                        [ ("firstname", string "maxime")
                          ("age", int 25)
                          ("address", object
                                        [ "street", string "main road"
                                          "city", string "Bordeaux"
                                        ])
                        ] |> encode
                equal expected actual

            testCase "option with a value `Some ...` works" <| fun _ ->
                let expected = """{ "id" : 1, "operator" : "maxime" }"""

                let actual =
                    object
                        [ ("id", int 1)
                          ("operator", option string (Some "maxime"))
                        ] |> encode

                equal expected actual

            testCase "option without a value `None` works" <| fun _ ->
                let expected = """{ "id" : 1, "operator" : null }"""

                let actual =
                    object
                        [ ("id", int 1)
                          ("operator", option string None)
                        ] |> encode

                equal expected actual

        ]

    ]