require 'rake/clean'

SELF_PATH = File.dirname(__FILE__)
PATH_TO_MSBUILD = "C:\\Windows\\Microsoft.NET\\Framework\\v3.5\\msbuild.exe"

# list of files and directories to clean, change to suit your liking
CLEAN.exclude("**/core")
CLEAN.include("*.cache", "*.xml", "*.suo", "**/obj", "**/bin", "../Deploy")

# builds all the .sln files in the directory
task :build do 
  desc "builds all of the .sln files in the current directory"
  Dir.glob('*.sln') do |file|
    sh "#{PATH_TO_MSBUILD} /v:q #{SELF_PATH}/#{file}"
  end
end

namespace "deploy" do
  desc "Preps the project for deployment"
  task :package, :project_name do |t, args|
    begin
      Rake::Task["clean"].invoke # clean everything up
      Rake::Task["build"].invoke # build the project
      Dir.mkdir("../Deploy") # make sure the deploy directory is present
      sh "xcopy .\\#{args.project_name} ..\\Deploy\\#{args.project_name}\\ /S /C /F /Y /exclude:e.txt"
      begin
        sh "xcopy .\\#{args.project_name}\\Web.config.prod ..\\Deploy\\#{args.project_name}\\Web.config /S /C /F /Y" 
      rescue
      end
    rescue Exception=>e
      puts e
    end
  end
end
