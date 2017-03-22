/// <binding AfterBuild='default' Clean='clean' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
*/

var gulp = require("gulp");
var srcmap = require("gulp-sourcemaps");
var ts = require("gulp-typescript");
var del = require("del");

var paths = {
    scripts: ["wwwroot/Content/typescripts/**/*.ts", "!wwwroot/Content/typescript/typings/*.d.ts"]
};

//gulp.task("clean", function () {
//    return del(["wwwroot/js/**/*"]);
//});

//gulp.task("default", function () {
//    return gulp.src(paths.scripts)
//         .pipe(srcmap.init())       
//         .pipe(srcmap.write())
//         .pipe(gulp.dest("wwwroot/js"));
//});

/**
 * Compiles all typescript into javascript..
 */
gulp.task("default",
    ["clean"],
    function () {
        return gulp.src(["wwwroot/Content/typescripts/**/*.ts", "!wwwroot/Content/typescript/typings/*.d.ts"])
            .pipe(srcmap.init())
            .pipe(ts({
                // Does not allow tsc to assume the any type where the type is not explicit. It is OK to use explicit any.
                noImplicitAny: true
            }))
            .on("error", function () { process.exit(1); })
            .pipe(srcmap.write())
            .pipe(gulp.dest("wwwroot/js"));
    });

/**
 * Removes all files from the js directories.
 */
gulp.task("clean",
    function () {
        return del([           
            "wwwroot/js/*"
        ]);
    });