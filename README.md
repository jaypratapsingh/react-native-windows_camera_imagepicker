# camera_imagepicker
*react-native-windows camera and image picker library in c#

For using this library you will.have to add both files in your project.

After adding the files, open you MainClass.cs and add new Class2() in List function.

Now in js file follow are the procedure to call function:

# import header file:

var mediaLibrary = require("NativeModule").Class1


# For Open Camera:

mediaLibrary.openCamera(function(success){
alert(success)
},function(error){
alert(error)
})

# For Open Gallery:

mediaLibrary.openCamera(function(success){
alert(success)
},function(error){
alert(error)
})
