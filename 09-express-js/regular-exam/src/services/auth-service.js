import bcrypt from "bcrypt";

import User from "../models/user.js";
import { generateToken } from "../common/functions.js";

export async function register(data) {
  if (data.password !== data.confirmPassword) {
    throw new Error("Passwords should match!");
  }

  const user = await User.findOne({ email: data.email }).select("_id");

  if (user) {
    throw new Error(
      `A user with email "${data.email}" is already registrated!`
    );
  }

  const createdUser = await User.create(data);

  return generateToken({
    id: createdUser._id,
    email: createdUser.email,
    username: createdUser.username,
  });
}

export async function login(data) {
  const user = await User.findOne({ email: data.email });

  if (!user) {
    throw new Error(`Invalid login attempt!`);
  }

  const passwordIsValid = await bcrypt.compare(data.password, user.password);

  if (!passwordIsValid) {
    throw new Error(`Invalid login attempt!`);
  }

  return generateToken({
    id: user._id,
    email: user.email,
    username: user.username,
  });
}
