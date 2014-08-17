// Generated on 2014-06-15 using generator-angular 0.9.0-1
'use strict';

// # Globbing
// for performance reasons we're only matching one level down:
// 'test/spec/{,*/}*.js'
// use this if you want to recursively match all subfolders:
// 'test/spec/**/*.js'

module.exports = function (grunt) {
    // Load grunt tasks automatically
    require('load-grunt-tasks')(grunt);

    // Time how long tasks take. Can help when optimizing build times
    require('time-grunt')(grunt);

    // Configurable paths for the application
    var appConfig = {
        app: require('./bower.json').appPath || 'app',
        dist: 'dist',
        tmp: '.tmp'
    };

    // Define the configuration for all the tasks
    grunt.initConfig({
        // Project settings
        yeoman: appConfig,

        // Watches files for changes and runs tasks based on the changed files
        watch: {
            bower: {
                files: ['bower.json'],
                tasks: ['wiredep']
            },
            js: {
                files: ['<%= yeoman.app %>/scripts/**/*.js'],
                tasks: ['newer:jshint:all'],
                options: {
                    livereload: '<%= connect.options.livereload %>'
                }
            },
            jsTest: {
                files: ['test/spec/**/*.js'],
                tasks: ['newer:jshint:test', 'karma']
            },
            styles: {
                files: ['<%= yeoman.app %>/styles/**/*.css'],
                tasks: ['newer:copy:styles', 'autoprefixer']
            },
            gruntfile: {
                files: ['Gruntfile.js']
            },
            livereload: {
                options: {
                    livereload: '<%= connect.options.livereload %>'
                },
                files: [
                    '<%= yeoman.app %>/**/*.html',
                    '.tmp/styles/**/*.css',
                    '<%= yeoman.app %>/images/**/*.{png,jpg,jpeg,gif,webp,svg}',
                    '<%= yeoman.app %>/templates/**/*.{png,jpg,jpeg,gif,webp,svg}',
                    '<%= yeoman.app %>/lib/**/*.{png,jpg,jpeg,gif,webp,svg}'
                ]
            }
        },

        // The actual grunt server settings
        connect: {
            options: {
                port: 9000,
                // Change this to '0.0.0.0' to access the server from outside.
                hostname: 'localhost',
                livereload: 35729
            },
            livereload: {
                options: {
                    open: true,
                    middleware: function (connect) {
                        return [
                            connect.static('.tmp'),
                            connect().use(
                                '/bower_components',
                                connect.static('./bower_components')
                            ),
                            connect.static(appConfig.app)
                        ];
                    }
                }
            },
            test: {
                options: {
                    port: 9001,
                    middleware: function (connect) {
                        return [
                            connect.static('.tmp'),
                            connect.static('test'),
                            connect().use(
                                '/bower_components',
                                connect.static('./bower_components')
                            ),
                            connect.static(appConfig.app)
                        ];
                    }
                }
            },
            dist: {
                options: {
                    open: true,
                    base: '<%= yeoman.dist %>'
                }
            }
        },

        // Make sure code styles are up to par and there are no obvious mistakes
        jshint: {
            options: {
                jshintrc: '.jshintrc',
                reporter: require('jshint-stylish')
            },
            all: {
                src: [
                    'Gruntfile.js',
                    '<%= yeoman.app %>/scripts/**/*.js'
                ]
            },
            test: {
                options: {
                    jshintrc: 'test/.jshintrc'
                },
                src: ['test/spec/**/*.js']
            }
        },

        // Empties folders to start fresh
        clean: {
            dist: {
                files: [{
                    dot: true,
                    src: [
                        '.tmp',
                        '<%= yeoman.dist %>/{,*/}*',
                        '!<%= yeoman.dist %>/.git*'
                    ]
                }]
            },
            server: '.tmp'
        },

        // Add vendor prefixed styles
        autoprefixer: {
            options: {
                browsers: ['last 1 version']
            },
            dist: {
                files: [{
                    expand: true,
                    cwd: '.tmp/styles/',
                    src: '**/*.css',
                    dest: '.tmp/styles/'
                }]
            }
        },

        // Automatically inject Bower components into the app
        //wiredep: {
        //    app: {
        //        src: ['<%= yeoman.app %>/index.html'],
        //        ignorePath: new RegExp('^<%= yeoman.app %>/|../')
        //    }

        // Automatically inject Bower components into the app
        //http://stackoverflow.com/questions/20912260/can-i-change-what-path-gets-rendered-when-using-bower-in-an-yeoman-angular-app
        wiredep: {
            app: {
                cwd: '',
                src: ['<%= yeoman.app %>/index.html'],
                ignorePath: new RegExp('^<%= yeoman.app %>')
            }

            //updated script to inject karma as well see: https://github.com/stephenplusplus/grunt-bower-install/issues/35#issuecomment-32084805
            /*
            ,
       test: {
          src: './test/karma.conf.js',
          fileTypes: {
            js: {
              block: /(([\s\t]*)\/\/\s*bower:*(\S*))(\n|\r|.)*?(\/\/\s*endbower)/gi,
              detect: {
                js: /'.*\.js'/gi
              },
              replace: {
                js: '\'{{filePath}}\','
              }
            }
          }
        }*/
        },

        // Renames files for browser caching purposes
        filerev: {
            dist: {
                src: [
                    '<%= yeoman.dist %>/lib/**/*.js',
                    '<%= yeoman.dist %>/templates/**/*.js',
                    '<%= yeoman.dist %>/lib/**/*.css',
                    '<%= yeoman.dist %>/templates/**/*.css',
                    '<%= yeoman.dist %>/scripts/**/*.js',
                    '<%= yeoman.dist %>/styles/**/*.css',
                    /* DONT RENAME IMAGES*/
                    //'<%= yeoman.dist %>/lib/**/*.{png,jpg,jpeg,gif,webp,svg}',
                    //                    '<%= yeoman.dist %>/templates/**/*.{png,jpg,jpeg,gif,webp,svg}',
                    //               '<%= yeoman.dist %>/images/**/*.{png,jpg,jpeg,gif,webp,svg}',
 //               '<%= yeoman.dist %>/styles/fonts/*'
                ]
            }
        },

        // Reads HTML for usemin blocks to enable smart builds that automatically
        // concat, minify and revision files. Creates configurations in memory so
        // additional tasks can operate on them
        useminPrepare: {
            html: ['<%= yeoman.app %>/setup/**/*.html', '<%= yeoman.app %>/index.html'],
            options: {
                dest: '<%= yeoman.dist %>',
                flow: {
                    html: {
                        steps: {
                            js: ['concat', 'uglifyjs'],
                            css: ['cssmin']
                        },
                        post: {}
                    }
                }
            }
        },

        // Performs rewrites based on filerev and the useminPrepare configuration
        usemin: {
            html: ['<%= yeoman.dist %>/**/*.html'],
            css: ['<%= yeoman.dist %>/styles/*.css'],
            options: {
                assetsDirs: ['<%= yeoman.dist %>', '<%= yeoman.dist %>/images']
            }
        },

        // The following *-min tasks will produce minified files in the dist folder
        // By default, your `index.html`'s <!-- Usemin block --> will take care of
        // minification. These next options are pre-configured if you do not wish
        // to use the Usemin blocks.
        // cssmin: {
        //   dist: {
        //     files: {
        //       '<%= yeoman.dist %>/styles/main.css': [
        //         '.tmp/styles/**/*.css'
        //       ]
        //     }
        //   }
        // },
        // uglify: {
        //   dist: {
        //     files: {
        //       '<%= yeoman.dist %>/scripts/scripts.js': [
        //         '<%= yeoman.dist %>/scripts/scripts.js'
        //       ]
        //     }
        //   }
        // },
        // concat: {
        //   dist: {}
        // },

        //imagemin: {
        //    dist: {
        //        files: [{
        //                expand: true,
        //                cwd: '<%= yeoman.app %>/images',
        //                src: '**/*.{png,jpg,jpeg,gif}',
        //                dest: '<%= yeoman.dist %>/images'
        //            },
        //            {
        //                expand: true,
        //                flatten: true,
        //                cwd: '<%= yeoman.app %>/lib',
        //                src: '**/images/**/*.{png,jpg,jpeg,gif}',
        //                dest: '<%= yeoman.dist %>/images'
        //            },
        //            {
        //                expand: true,
        //                flatten: true,
        //                cwd: '<%= yeoman.app %>/templates',
        //                src: '**/images/**/*.{png,jpg,jpeg,gif}',
        //                dest: '<%= yeoman.dist %>/images'
        //            }
        //        ]
        //    }
        //},
        imagemin: {
            dist: {
                files: (function () {
                    grunt.log.subhead('IMAGE MOVE PROCESS START-------------------------------------------');
                    var pathName = ['images', 'img'];
                    var specialFolders = ['lib', 'templates'];

                    var destinations = ['dist', 'app'];

                    var fArray = [];

                    fArray.push({
                        expand: true,
                        cwd: '<%= yeoman.app %>/images',
                        src: '**/*.{png,jpg,jpeg,gif}',
                        dest: '<%= yeoman.dist %>/images'
                    });
                    var createCwd = function (specialFolder, pathN) {
                        var path = grunt.file.expand('app/' + specialFolder + '/*/**/' + pathN + '/')[0];

                        return path;
                    };

                    for (var k = 0; k < specialFolders.length; k++) {
                        grunt.log.ok('preparing to move stuff to destination: ' + destinations[k] + '..............');
                        for (var i = 0; i < pathName.length; i++) {
                            grunt.log.ok('looking for folder:  ' + pathName[i] + '..........');
                            for (var j = 0; j < specialFolders.length; j++) {
                                grunt.log.ok('looking in special folder:  ' + specialFolders[j] + '..........');

                                var opt = {};
                                grunt.log.writeln('-------------------------------------------');
                                opt.expand = true;
                                opt.cwd = createCwd(specialFolders[j], pathName[i]);
                                opt.src = ['**/*.{png,jpg,jpeg,gif}'];
                                opt.dest = '<%= yeoman.' + destinations[k] + ' %>/' + pathName[i];

                                grunt.log.writeln('cwd=' + opt.cwd);
                                grunt.log.writeln('src=' + opt.src);
                                grunt.log.writeln('dest=' + opt.dest);

                                var willPush = opt && opt.cwd;

                                willPush ? grunt.log.ok('OK******') : grunt.log.error('REJECTED ****');

                                willPush && fArray.push(opt);
                                grunt.log.writeln('-------------------------------------------');
                            }
                        }
                    }
                    grunt.log.subhead('IMAGE MOVE PROCESS END-------------------------------------------');
                    return fArray;
                })()
            }
        },
        svgmin: {
            dist: {
                files: [{
                    expand: true,
                    cwd: '<%= yeoman.app %>',
                    src: '**/*.svg',
                    dest: '<%= yeoman.dist %>/images'
                }]
            }
        },

        htmlmin: {
            dist: {
                options: {
                    collapseWhitespace: true,
                    conservativeCollapse: true,
                    collapseBooleanAttributes: true,
                    removeCommentsFromCDATA: true,
                    removeOptionalTags: true
                },
                files: [{
                    expand: true,
                    cwd: '<%= yeoman.dist %>',
                    src: ['*.html', 'views/**/*.html', 'setup/**/*.html'],
                    dest: '<%= yeoman.dist %>'
                }]
            }
        },

        // ngmin tries to make the code safe for minification automatically by
        // using the Angular long form for dependency injection. It doesn't work on
        // things like resolve or inject so those have to be done manually.
        ngmin: {
            dist: {
                files: [{
                    expand: true,
                    cwd: '.tmp/concat/scripts',
                    src: '*.js',
                    dest: '.tmp/concat/scripts'
                }]
            }
        },

        // Replace Google CDN references
        cdnify: {
            dist: {
                html: ['<%= yeoman.dist %>/*.html']
            }
        },

        // Copies remaining files to places other tasks can use
        copy: {
            dist: {
                files: [{
                    expand: true,
                    dot: true,
                    cwd: '<%= yeoman.app %>',
                    dest: '<%= yeoman.dist %>',
                    src: [
                        '*.{ico,png,txt}',
                        '.htaccess',
                        '*.html',
                        'views/**/*.html',
                        'setup/**/*.html',
                        'images/**/*.{webp}',
                        'fonts/*'
                    ]
                }, {
                    expand: true,
                    cwd: '.tmp/images',
                    dest: '<%= yeoman.dist %>/images',
                    src: ['generated/*']
                }, {
                    expand: true,
                    cwd: 'bower_components/bootstrap/dist',
                    src: 'fonts/*',
                    dest: '<%= yeoman.dist %>'
                }]
            },
            styles: {
                expand: true,
                cwd: '<%= yeoman.app %>/styles',
                dest: '.tmp/styles/',
                src: '**/*.css'
            }
        },

        // Run some tasks in parallel to speed up the build process
        concurrent: {
            server: [
                'copy:styles'
            ],
            test: [
                'copy:styles'
            ],
            dist: [
                'copy:styles',
                'imagemin',
                'svgmin'
            ]
        },

        // Test settings
        karma: {
            unit: {
                configFile: 'test/karma.conf.js',
                singleRun: true
            }
        },

        remove: {
            options: {
                trace: true
            },
            fileList: [],
            dirList: ['.tmp', 'dist']
        }
    });

    // grunt.registerTask('imagepng', ['imagemin:png']);

    grunt.registerTask('serve', 'Compile then start a connect web server', function (target) {
        if (target === 'dist') {
            return grunt.task.run(['build', 'connect:dist:keepalive']);
        }

        grunt.task.run([
            'clean:server',
            'wiredep',
            'concurrent:server',
            'autoprefixer',
            'connect:livereload',
            'watch'
        ]);
    });

    grunt.registerTask('server', 'DEPRECATED TASK. Use the "serve" task instead', function (target) {
        grunt.log.warn('The `server` task has been deprecated. Use `grunt serve` to start a server.');
        grunt.task.run(['serve:' + target]);
    });

    grunt.registerTask('test', [
        'clean:server',
        'concurrent:test',
        'autoprefixer',
        'connect:test',
        'karma'
    ]);

    grunt.registerTask('build', [
        'clean:dist',
        'wiredep',
        'useminPrepare',
        'concurrent:dist',
        'autoprefixer',
        'concat',
        'ngmin',
        'copy:dist',
        'cdnify',
        'cssmin',
        'uglify',
        'filerev',
        'usemin',
        'htmlmin'
    ]);

    grunt.registerTask('default', [
        'newer:jshint',
        'test',
        'build'
    ]);
};