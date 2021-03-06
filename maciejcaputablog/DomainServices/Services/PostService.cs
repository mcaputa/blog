﻿using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models.DomainModels;

namespace DomainServices.Services
{
    using System;

    using Core.Entities;

    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;

        public PostService(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public AllPostsDomainModel GetAllPosts()
        {
            var allPostsDomainModels = this.postRepository.GetAllPosts();

            var postsViewModel = new AllPostsDomainModel()
            {
                PostPreviewStorageModels = allPostsDomainModels
            };
            return postsViewModel;
        }

        public PostDomainModel GetPost(string friendlyTitle)
        {
            var post = this.postRepository.GetPost(friendlyTitle);

            var postDomainModel = new PostDomainModel(post);
            
            return postDomainModel;
        }

        public void CreatePost(PostDomainModel postDomainModel)
        {
            this.postRepository.CreatePost(postDomainModel.PostStorageModel);
        }
    }
}
