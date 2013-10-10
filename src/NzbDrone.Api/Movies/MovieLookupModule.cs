﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using NzbDrone.Api.Extensions;
using NzbDrone.Api.Mapping;
using NzbDrone.Core.MediaCover;
using NzbDrone.Core.MetadataSource;

namespace NzbDrone.Api.Movies
{
    public class MovieLookupModule : NzbDroneRestModule<MoviesResource>
    {
        private readonly ISearchForNewMovie _searchProxy;

        public MovieLookupModule(ISearchForNewMovie searchProxy):base("/Movies/lookup")
        {
            _searchProxy = searchProxy;
            Get["/"] = x => Search();
        }

        private Response Search()
        {
            var results = _searchProxy.SearchForNewMovie((string) Request.Query.term);
            return MapToResource(results).AsResponse();
        }

        private static IEnumerable<MoviesResource> MapToResource(List<Core.Movies.Movie> movies)
        {
            foreach (var currentMovie in movies)
            {
                var resource = currentMovie.InjectTo<MoviesResource>();
                var poster = currentMovie.Images.FirstOrDefault(c => c.CoverType == MediaCoverTypes.Poster);
                if (poster != null)
                {
                    resource.RemotePoster = poster.Url;
                }

                yield return resource;
            }
        }
    }
}