﻿using Common.Application;
using Shop.Domain.CommentAgg;

namespace Shop.Application.Comments.ChangeStatus;

public record ChangeCommentStatusCommand(long Id , Comment.CommentStatus Status):IBaseCommand;